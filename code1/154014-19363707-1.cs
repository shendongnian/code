    using (var conn = new MySqlConnection(cs))
    {
        conn.Open();
        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM test", conn))
        {
             int count = Convert.ToInt32(cmd.ExecuteScalar());
             return count;
        }
    }
