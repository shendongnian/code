    DbCommand CreateCommand(string commandText)
    {
        DbCommand newCommand = null;
        bool success = false;
        try
        {
            newCommand = connection.CreateCommand();
            newCommand.CommandText = commandText;
            success = true;
            return newCommand;
        }
        finally
        {
            if (!success & newCommand != null)
                newCommand.Dispose();
         }
    }
