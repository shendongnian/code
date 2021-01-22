    using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM test", conn))
    {
        using (MySqlDataReader r = cmd.ExecuteReader())
        {
            r.Read();
            Guid id = new Guid((byte[])r[0]);
        }
    }
