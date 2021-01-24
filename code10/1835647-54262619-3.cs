    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
          
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-R0N4ID3;Initial Catalog=testOnedb;Integrated Security=True"))
            {
                conn.Open();
              
                using (SqlCommand com = new SqlCommand("select * from testOnetable", conn))
                {
                    using (SqlDataReader read = com.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            listBox1.Items.Add("the username : " + read["username"].ToString() + "\n the passward : " + read["passward"].ToString() + "\n the email : " + read["email"].ToString());
                        }
                        
                        read.Close();
                    }
                }
                
                conn.Close();
            }
        }
        private void student_Load(object sender, EventArgs e)
        {
        }
    }
