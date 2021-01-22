    public IDataReader ExecuteReader(string commandText, CommandType commandType, 
                                          IDbDataParameter[] parameters)
    {
        IDbConnection connection = CreateConnection();
        try
        {
            IDbCommand command = CreateCommand(commandText, connection);
            command.CommandType = commandType;
            AppendParameters(command, parameters);
            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch
        {
            connection.Close();
            throw;
        }
    }
