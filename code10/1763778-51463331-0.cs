    DataTable dt = new DataTable();
    using(SqlConnection conn = new SqlConnection("connectionString"))
    {
        using(SqlCommand com = new SqlCommand())
        {
            com.CommandText = "select * from account " + //don't forget about space here!
                                      "where username = @username and password = @password";
            com.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUsername.Text;
            com.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Text;
            com.Connection = conn;
            using(SqlDataAdapter adapter = new SqlDataAdapter(com))
            {
                conn.Open();
                adapter.Fill(dt);
            }
        }
    }
