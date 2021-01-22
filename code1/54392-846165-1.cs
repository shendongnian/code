        public static int NonQuery(string sql)
        {
            Dictionary<string, object> parameters = null;
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    foreach (KeyValuePair<string, object> p in parameters)
                    {
                        var parameter = command.CreateParameter();
                        parameter.ParameterName = p.Key;
                        parameter.Value = p.Value;
                        command.Parameters.Add(parameter);
                    }
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
