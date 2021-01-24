    string sql = "select count(*) from users where username = '" + username + "' and password = '" + password + "'";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
        conn.Open();
     
        using (SqlCommand command = new SqlCommand(query, conn))
        {
            int result = (int)command.ExecuteScalar();
            if (result > 0)
            {
                /// login sucessful
            }
        }
    }
