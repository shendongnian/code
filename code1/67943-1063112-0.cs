    using (SqlConnection connection = openConnection())
    {
        command.Connection = connection;
        ExecuteReaderWithCommand(command, reader =>
        {
            // Do stuff with the result here.
        });
    }
