using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class Form1 : Form
    {

        public DataTable mytable;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        DataSet ds = new DataSet();
        SqlConnection mycon;
        SqlDataAdapter da;
        private void Form1_Load(object sender, EventArgs e)
        {
            string strconnection = @"Data Source=HERO\RADWA_AYMAN; Integrated Security=true ; Initial Catalog=BookStore";
            mycon = new SqlConnection(strconnection);
            mycon.Open();
            try
            {
                da = new SqlDataAdapter("SELECT * FROM Customers; SELECT * FROM Scientific; SELECT * FROM Adventure; SELECT * FROM Art;SELECT * FROM Kids;SELECT * FROM Cultural ; SELECT * FROM Literature ; SELECT * FROM Novels", mycon);
                da.TableMappings.Add("Table", "Customers");
                da.TableMappings.Add("Table1", "Scientific");
                da.TableMappings.Add("Table2", "Adventure");
                da.TableMappings.Add("Table3", "Art");
                da.TableMappings.Add("Table4", "Kids");
                da.TableMappings.Add("Table5", "Cultural");
                da.TableMappings.Add("Table6", "Literature");
                da.TableMappings.Add("Table7", "Novels");

                da.Fill(ds);
  //              dataGridView1.DataSource = ds;
  //              dataGridView1.DataMember = "Customers";
            }
            catch (Exception exp)
            {
                MessageBox.Show("" + exp);
            }
        }
        string s;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Scientific
            Adventure
            Art
            Fashion
            Literature
            Entertainment
            Novels
            kids*/
            s = comboBox2.Text;
            listBox1.DataSource = ds.Tables[s];
            //listBox1.ValueMember = "id";
            listBox1.DisplayMember = "name";
        }
        int count , totalCount=0;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            //MessageBox.Show("" +count);
            //label12.Text = "" + count; 
        }
        int cost = 0;
        private void button1_Click_1(object sender, EventArgs e)   // add
        {

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please choose books to add");
                return;
            }

            int index = listBox1.SelectedIndex;
            string selected = (string)ds.Tables[s].Rows[index]["name"];
            //MessageBox.Show(selected);
            int num = (int)ds.Tables[s].Rows[index]["num"];
            //MessageBox.Show("" +num);
            if (num >= count)
            {
                listBox2.Items.Add(selected);
                cost += count * (int)ds.Tables[s].Rows[index]["cost"] ;
                //MessageBox.Show("" +cost);
                label12.Text = "" + cost + " $";
                num -= count;
                totalCount += count;
                ds.Tables[s].Rows[index]["num"] = num;
            }
            else
            {
                MessageBox.Show("Out of Stock\nAvailable = " + num);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

        }
        string Bselected="";
        private void radioButton1_CheckedChanged(object sender, EventArgs e) //borrow
        {
            if (radioButton1.Checked)
            {
                MessageBox.Show("The available period is 3 days"); // timer
                groupBox2.Enabled = false;     //payment
                Bselected = "Borrow";
                button3.Enabled = true;        //submit
                label11.Visible = false;
                label12.Visible = false;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)  //buy
        {
             if (radioButton2.Checked)
            {
                groupBox2.Enabled = true;  //payment
                Bselected = "Buy";
                button3.Enabled = false;   //submit
                label11.Visible = true;
                label12.Visible = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e) //cash
        {
            if (radioButton3.Checked)
            {
                button3.Enabled = true;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e) //credit
        {
            if (radioButton4.Checked)
            {
                panel1.Visible = true;
                button3.Enabled = false;
                    

            }
        }
        private void button4_Click(object sender, EventArgs e) //ok
        {
                string n1 = textBox3.Text;
                string n2 = textBox4.Text;
                string n3 = textBox5.Text;
                if(n1 != "" && n2 !="" && n3 != "")
                {
                    button3.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please enter your Credit Card details");
                    return;
                }
            //ckeck cost in withdrawn
            if (radioButton2.Checked && Convert.ToInt32(textBox5.Text) < cost)
            {
                MessageBox.Show("withdrawn is not enough ");
                return;
            }
            else
            {
                MessageBox.Show("successful operation");

            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //press enter
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
                e.Handled = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox2.Focus();
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
                e.Handled = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
          
                if (e.KeyCode == Keys.Enter)
                {
                    textBox4.Focus();
                    e.Handled = true;
                }
            }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.Focus();
                e.Handled = true;
            }
        }

        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.Focus();
                e.Handled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { 
            if(listBox2.Items.Count == 0)
            {
                MessageBox.Show("Please choose books");
                return;
            }
            // add data of customers
            DataRow dr = ds.Tables["Customers"].NewRow();
            try
            {
                dr["name"] = textBox1.Text;
                dr["id"] = Convert.ToInt32(textBox2.Text);
                dr["age"] = Convert.ToInt32(textBox6.Text);
                dr["Buy/Borrow"] = Bselected;
                dr["numOfBooks"] = totalCount;
                // list for books
                string books = "";
                foreach (var item in listBox2.Items)
                {
                    books += item.ToString() + "    ";
                }
                dr["nameOfBooks"] = books;
                dr["cost"] = cost;
            }
            catch(Exception EXP)
            {
                MessageBox.Show("Please enter data");
                return;
            }
                ds.Tables["Customers"].Rows.Add(dr);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds, "Customers");
                MessageBox.Show("Done");

        }



        /*from form load
         * if (mycon.State == ConnectionState.Open)
            {
                //MessageBox.Show("connection stablished");
            }

            try
            {
                SqlCommand command1 = new SqlCommand("Create database hello", mycon);
                command1.ExecuteNonQuery();
                command1.Connection.ChangeDatabase("hello");
                MessageBox.Show("database created");

            }
            catch (Exception exp)
            {
                mycon.ChangeDatabase("hello");
                MessageBox.Show("handled");
            }

            try
            {
                SqlCommand command2 = new SqlCommand("create table try.dbo.UserDetails ([name] varchar(255) , [id] int , [age] int , [numOfBooks] int ,[nameOfBooks] varchar(1000) , [cost] int)");
                command2.ExecuteNonQuery();
                MessageBox.Show("table created");
                command2.Connection.ChangeDatabase("try");

            }
            catch (Exception exp)
            {
            //    mycon.ChangeDatabase("try");
                MessageBox.Show("handled table");
            }
            try
            {
                da = new SqlDataAdapter("SELECT * from try", mycon);
                da.Fill(ds);
                dataGridView1.DataSource = ds;

            }
            catch (Exception exp)
            {
                MessageBox.Show(""+exp);
            }*/
    }
}
