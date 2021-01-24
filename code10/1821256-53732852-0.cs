    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    namespace QueryExample {
        public class Query {
            private readonly SqlConnection _connection;
            public Query(SqlConnection connection) {
                _connection = connection;
            }
            public IEnumerable<T> Run<T>(string text, Func<SqlDataReader, T> builder) {
                var results = new List<T>();
                try {
                    _connection.Open();
                    using (var command = new SqlCommand()) {
                        command.Connection = _connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = text;
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                                results.Add(builder(reader));
                    }
                    _connection.Close();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                return results;
            }
        }
    }
