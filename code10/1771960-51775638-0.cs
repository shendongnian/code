    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Data.OleDb;
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    private void button2_Click(object sender, EventArgs e)
    {
        OleDbConnection conn = new OleDbConnection();
        conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ryan\Desktop\Coding\Microsoft Access\Northwind.mdb";
        string fstName  = textBox1.Text.Trim();
        string lstName  = textBox2.Text.Trim();
        string adres = textBox3.Text.Trim();
        OleDbCommand cmd = new OleDbCommand(@"INSERT INTO MyExcelTable (FName, LName, Address) VALUES (@FName, @LName, @Address)")
        {
            Connection = conn
        };
        conn.Open();
        if (conn.State == ConnectionState.Open)
        {
            // you should always use parameterized queries to avoid SQL Injection
            cmd.Parameters.Add("@FName", OleDbType.VarChar).Value = fstName;
            cmd.Parameters.Add("@LName", OleDbType.VarChar).Value = lstName;
            cmd.Parameters.Add("@Address", OleDbType.VarChar).Value = adres;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(@"Data Added");
                conn.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message);
                conn.Close();
            }
        }
        else
        {
            MessageBox.Show(@"Connection Failed");
        }
    }
       }
    }
