        public class Form1
        {   
            private SqlConnection conn;
            private SqlCommand command;
            private SqlDataReader reader;
        public Form1()
        {
    
         conn = new SqlConnection("Data Source=JOSHMAV-PC\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
         command = new SqlCommand("SELECT * "+ "FROM question", conn);
         try
         {
              conn.Open();
              reader = command.ExecuteReader();
         }
          catch (SqlException ex)
                {
        
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
         }
     private void button1_Click(object sender, EventArgs e)
            {
                
                
                    if (reader.Read())
                    {
                        //MessageBox.Show(reader["C1"].ToString());
                        ques.Text = reader["ques"].ToString();
                        radioButton1.Text = reader["C1"].ToString();
                        radioButton2.Text = reader["C2"].ToString();
                        radioButton3.Text = reader["C3"].ToString();
                        radioButton4.Text = reader["C4"].ToString();
        
        
                    }
                else reader.Close();
                }
                
        
            }
