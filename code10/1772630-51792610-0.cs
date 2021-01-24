    string myconnstring = ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
     
         
        SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "UPDATE UsersTable SET Loggedin = '0' WHERE username = @userName";              
                SqlCommand cmd = new SqlCommand(sql, conn);          
                cmd.Parameters.AddWithValue("@userName", txtlogoutusername.Text);
                conn.Open();
                int rowsAffected =cmd.ExecuteNonQuery();
                Console.WriteLine("rows affected: " + rowsAffected);
            }
            catch(Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
