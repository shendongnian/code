    using (var conn = new SQLiteconnection(connectionString))
    using (var command = conn.CreateCommand())
    {
        conn.Open();
        command.CommandText = "select name from persons where id = @id";
        command.Parameters.AddWithValue("@id", 5);
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
    
            }
        }
    }
