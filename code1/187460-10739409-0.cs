    public static int RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                int rowsAffected;
                OracleCommand command = new OracleCommand(storedProcName, connection);
                command.CommandText = storedProcName;
                command.CommandType = CommandType.StoredProcedure;
                foreach (OracleParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                connection.Open();
                try
                {
                    // start transaction
                    command.Transaction = connection.BeginTransaction();
                    rowsAffected = command.ExecuteNonQuery();
                    command.Transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    command.Transaction.Rollback();
                    throw ex;
                }
                connection.Close();
                return rowsAffected;
            }
        }
