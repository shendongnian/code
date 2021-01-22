        private static T ExecuteSingle<T>(string connectionString, string sprocName, params object[] sprocParameters)
            where T : class
        {
            var commandText = sprocName;
            if (sprocParameters.Length > 0)
            {
                // http://stackoverflow.com/questions/859985/linq-executecommand-doesnt-understand-nulls
                int counter = 0;
                var nulledPlaceholders = sprocParameters
                    .Select(x => x == null ? "NULL" : "{" + counter ++ + "}");
                commandText += " " + string.Join(",", nulledPlaceholders);
                sprocParameters = sprocParameters.Where(x => x != null).ToArray();
            }
            var connection = new SqlConnection(connectionString);
            var dc = new DataContext(connection);
            return dc.ExecuteQuery<T>(commandText, sprocParameters).SingleOrDefault();
        }
