    using(SqlConnection conn = new SqlConnection(connString))
    {
        SqlCommand command = 
            new SqlCommand("SELECT * FROM Users WHERE Username = @Username", conn);
        command.Parameters.Add(new SqlParameter("@Username", "Justin Niessner"));
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
    }
