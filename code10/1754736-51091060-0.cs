    int count = 0;
    using (var conn = new OracleConnection("Some connection string"))
    {
        conn.Open();
        
        using (var cmd = conn.CreateCommand())
        {    
            cmd.CommandText = "select count(*) from users";
            count = (int)cmd.ExecuteScalar();
        }
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select * from users";
            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read()) {
                    [...]
                }
            }
        }
    }
