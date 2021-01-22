     public virtual object ExecuteScalar(DbCommand command)
            {
                if (command == null) throw new ArgumentNullException("command");
    
                using (ConnectionWrapper wrapper = GetOpenConnection())
                {
                    PrepareCommand(command, wrapper.Connection);
                    return DoExecuteScalar(command);
                }
            }
       
