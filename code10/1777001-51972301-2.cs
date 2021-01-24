        public List<IDictionary<string, object>> DapperSelect(string connectionString, string query, object parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var result = connection.Query(query, parameters).ToList();
                return result.Select(x => (IDictionary<string, object>)x).ToList();
            }
        }
