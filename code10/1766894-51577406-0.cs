    var connString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";
    using (DbConnection conn = new NpgsqlConnection(connString))
    {
        conn.Open()
        using (DbCommand command = conn.CreateCommand())
        {
            // etc
        }
    }
