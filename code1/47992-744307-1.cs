    public SqlDataReader ExecuteReader(string commandText)
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        try
        {
            connection = new SqlConnection(...);
            connection.Open();
            command = new SqlCommand(commandText, connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch
        {
            // Close connection before rethrowing
            command.Close();
            connection.Close();
            throw;
        }
    }
