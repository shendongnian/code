    public static List<T> ReadRows<T>(this SqlHelper sql, string query, SqlParameter[] 
    parameters, Func<SqlDataReader, T> projection)
    {
            var command = GetSqlCommand(query, CommandType.StoredProcedure, parameters);
            return sql.ExecuteReader(command, reader => reader.Select(projection).ToList());
    }
