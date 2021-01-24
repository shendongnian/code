    using (var connection = new SqliteConnection("conn-string"))
    {
        connection.Open();
        using (var transaction = connection.BeginTransaction())
        {
            for (int i = 0; i < 1000000; i++)
            {
                string sql = $"insert into table1 (id) values ({i})";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            transaction.Commit();
        }
    }
