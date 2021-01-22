        public static DbCommand CreateCommand(this DbConnection connection, string commandText)
        {
            DbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            return command;
        }
