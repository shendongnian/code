        public ICollection<T> Execute<T>(string query, Func<IDataReader, T> map, IDictionary<string, object> parameters = null)
        {
            ICollection<T> collection = new List<T>();
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                using (SqlCommand command = CreateCommand(connection, query, parameters))
                {
                    using (IDataReader reader = await command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            collection.Add(map.Invoke(reader));
                        }
                    }
                }
                connection.Close();
            }
            return collection;
        }
