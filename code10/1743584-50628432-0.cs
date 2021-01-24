    public static class QueryExtensions
    {
        public static DataTable ExecuteQuery(this DbContext db, string commandText, CommandType commandType, IEnumerable<SqlParameter> parameters)
        {
            var conn = db.Database.Connection;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;
                    command.Parameters.AddRange(parameters.ToArray());
                    using (var reader = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) 
                    conn.Close();
            }
        }
    }
