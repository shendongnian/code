    using (DbConnection connection = GetConnection())
    using (DbCommand command = connection.CreateCommand())
    {
        command.CommandText = "SELECT FOO, BAR FROM BAZ";
        connection.Open();
        using (DbDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                ....
            }
        }
    }
