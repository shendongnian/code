    using (var connection = new SqlConnection(ConnectionString))
    using (var command = connection.CreateCommand())
    {
        connection.Open();
        command.CommandText = "select id from test1; select id from test2";
        using (var reader = command.ExecuteReader())
        {
            do
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0));
                }
                Console.WriteLine("--next command--");
            } while (reader.NextResult());
        }
    }
