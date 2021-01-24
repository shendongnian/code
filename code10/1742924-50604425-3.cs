    using (MySqlConnection conn = new MySqlConnection(connectionString))
    { 
    conn.Open();
        using (MySqlTransaction trans = conn.BeginTransaction())
        {
            using (MySqlCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
             trans.Commit();
        }
    }
