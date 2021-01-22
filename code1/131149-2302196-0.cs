    public void SomeMethod()
    {
        using (var connection = new SqlConnection(connectionString))
        using (var command = connection.CreateCommand())
        {
            connection.Open();
            command.CommandText = "SELECT Field1 FROM Table1";
            using (var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    // do something with the results
                }
            }
        }
    }
