        public List<IDictionary<string, object>> DapperSelect(string ConnectionString, string Query, object parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query(Query, parameters).ToList();
                return results.Select(x => (IDictionary<string, object>)x).ToList();
            }
        }
