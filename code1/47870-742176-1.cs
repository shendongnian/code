    string connectionString = string.Format("Server={0};Database={1};Uid={2};pwd={3}", "server", "database", "user", "password");
    
    Guid orgId = Guid.NewGuid();
    Guid fromDb = Guid.Empty;
    
    using (MySqlConnection conn = new MySqlConnection(connectionString))
    {
        conn.Open();
    
        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO test (id) VALUES (?id)", conn))
        {
            cmd.Parameters.Add("id", MySqlDbType.Binary).Value = orgId.ToByteArray();
            cmd.ExecuteNonQuery();
        }
    
        using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM test", conn))
        {
            using (MySqlDataReader r = cmd.ExecuteReader())
            {
                r.Read();
                fromDb = new Guid((byte[])r.GetValue(0));
            }
        }
    }
