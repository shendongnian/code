    string sql = "select count(*) from login where username = @username and password = @password";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
        conn.Open();
     
        using (SqlCommand command = new SqlCommand(query, conn))
        {
            command.Parameters.Add(new SqlParameter("@username", username));
            command.Parameters.Add(new SqlParameter("@password", password));
            int result = (int)command.ExecuteScalar();
            if (result > 0)
            {
                /// login sucessful
            }
        }
    }
