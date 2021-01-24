    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            string connetionString;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommandBuilder cmdBuilder;
            DataSet ds = new DataSet();
            DataSet changes;
            string Sql;
            Int32 i; 
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                connection = new SqlConnection(connetionString);
                Sql = "select * from Product";
                try
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(Sql, connection);
                    adapter.Fill(ds);
                    connection.Close();
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show (ex.ToString());
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                try
                {
                    cmdBuilder = new SqlCommandBuilder(adapter);
                    changes = ds.GetChanges();
                    if (changes != null)
                    {
                        adapter.Update(changes);
                    }
                    MessageBox.Show("Changes Done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
