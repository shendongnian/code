      using (iDB2Command command = new iDB2Command())
            {
                command.Connection = (iDB2Connection)_connection;
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue(Constants.ParamInterfaceTransactionNo, 1);
                command.CommandText = dynamicInsertString;
                command.ExecuteScalar();
            }
