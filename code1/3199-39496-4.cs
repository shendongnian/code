        public IEnumerable<T> Read<T>(string sql, Func<IDataReader, T> make, params object[] parms)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateCommand(CommandType.Text, sql, connection, parms))
                {
                    command.CommandTimeout = dataBaseSettings.ReadCommandTimeout;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return make(reader);
                        }
                    }
                }
            }
        }
