    string command = "SELECT * FROM Users WHERE  username = @username and password= @password";
    using (SqlConnection mConnection = new SqlConnection(ConnectionString))
    {
        mConnection.Open();
        using (SqlCommand cmd = new SqlCommand(command, mConnection))
        {
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = textBoxUserName.Text.Trim();
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = textBoxPassword.Text.Trim();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    count = count + 1;
                    userRole = myReader["userrank"].ToString();
                }
            }
        }
    }
