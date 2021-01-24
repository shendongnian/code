        string userID;
    
    using(SqlConnection conn = new SqlConnection(connectionString))
    {
                string insertQuery = "SELECT UserID FROM Customers WHERE Email = @Email AND 
                Password = @Password";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Email", tbEmail.Text.ToString().Trim());
                com.Parameters.AddWithValue("@Password", tbPassword.Text.ToString().Trim());
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                  userID = reader["UserID"].ToString();
                }
    }
            
