    public SqlDataReader ExecuteReader(string commandText)
    {
        SqlConnection connection = new SqlConnection(...);
        try
        {
            connection.Open();
            using(SqlCommand command = new SqlCommand(commandText, connection))
            {
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        catch
        {
            // Close connection before rethrowing
            connection.Close();
            throw;
        }
    }
