    public DbCommand CreateCommand()
        {
            if (this._baseCommand.Transaction != null)
            {
                DbCommand command = this._baseConnection.CreateCommand();
                command.Transaction = this._baseCommand.Transaction;
                return command;
            }
            return this._baseConnection.CreateCommand();
        }
