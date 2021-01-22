    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        SqlTransaction transaction;
        // Start a local transaction.
        transaction = connection.BeginTransaction("SampleTransaction");
        // Must assign both transaction object and connection
        // to Command object for a pending local transaction
        command.Connection = connection;
        command.Transaction = transaction;
        ...
        ...
    }
