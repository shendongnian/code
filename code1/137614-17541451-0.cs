    try
    {
        Console.WriteLine("Connecting to: {0}", AppConfig.ConnectionString);
        using (var connection = new SqlConnection(AppConfig.ConnectionString))
        {
            var query = "select 1";
            Console.WriteLine("Executing: {0}", query);
            var command = new SqlCommand(query, connection);
            connection.Open();
            Console.WriteLine("SQL Connection successful.");
            command.ExecuteScalar();
            Console.WriteLine("SQL Query execution successful.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Failure: {0}", ex.Message);
    }
