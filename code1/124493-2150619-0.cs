    using (var connection = new SqlConnection(connectionString))
    {
        using (var command = new SqlCommand(commandString, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                 // Use the reader
            }
        }
    }
