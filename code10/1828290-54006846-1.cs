            private void AddParameter(IDbCommand command, string parameter, object value)
            {
                IDbDataParameter param = command.CreateParameter();
                param.ParameterName = parameter;
                param.Value = value;
    
                command.Parameters.Add(param);
            }
    
            private SqlCommand CreateCommand(SqlConnection connection, string query, 
                IDictionary<string, object> parameters = null)
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = query;
    
                if(parameters != null && parameters.Count > 0)
                {
                    foreach(KeyValuePair<string, object> parameter in parameters)
                    {
                        AddParameter(command, parameter.Key, parameter.Value);
                    }
                }
    
                return command;
            }
