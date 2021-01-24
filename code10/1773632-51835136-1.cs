        public bool ExecuteNonQuery(string query, object[] parameters, [CallerMemberName] string callerMemberName = "")
        {
            bool success = false;
            try
            {
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = _connection;
                    command.Transaction = _transaction;
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(parameters);
                    
                    command.ExecuteNonQuery();
                }
                this.AuditSQL(query, string.Empty);
                success = true;
            }
            catch (OracleException ex)
            {
                this.AuditSQL(query, ex.Message, callerMemberName);
                if (ex.Number == 54) // SELECT .. FOR UPDATE NOWAIT failed.
                {
                    throw new RowLockException();
                }
            }
            return success;
        }
