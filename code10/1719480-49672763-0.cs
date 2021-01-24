    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
  
        string textInst {get;set;}
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textInst = textBox1.Text;
        }
    
    
    private void openDBBut_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
        }
    }
    
    private void instBut_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn2 = new SqlConnection(connString))
        {
            string query = "INSERT INTO CUSTOMERS(Name) VALUES(@textInst)";
            using(SqlCommand cmd = new SqlCommand(query, conn2))
            {
                cmd.Parameters.AddWithValue("@textInst", textInst);
            }
        }
    }
    
    private void closeDBBut_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn3 = new SqlConnection(connString))
        {
            conn3.Close();
        }
     
    
       }
     }
    }
