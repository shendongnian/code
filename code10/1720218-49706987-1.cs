     private void Form1_Load(object sender, EventArgs e)
            {
                DataTable dataTable= new DataTable();
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from tblProductInventory", con);
                    dataGridView1.DataSource = cmd.ExecuteReader();   
            
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                 }   
               dataGridView1.DataSource = dataTable;  
             
                }  
           }
