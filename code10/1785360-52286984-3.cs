    public bool Authorize(string userName, string userPassword)
           {
                Connection connection = new Connection();
                string sql = "SELECT * FROM tbl_Account WHERE Username=@userName and Password=@userPassword";
                MySqlConnection conn = new MySqlConnection(connection.ConnectionString);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userName",userName);
                cmd.Parameters.AddWithValue("@userPassword",userPassword);
                int count = 0;
                try
                {
                   conn.Open();
                   MySqlDataReader dr = cmd.ExecuteReader();
                
        
                   while (dr.Read())
                   {
                       count++;
                   }
                }
                finally
                {
                  con.Close();
                }
                return count==1;
           }
