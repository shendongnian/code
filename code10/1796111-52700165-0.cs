    public T Execute<T>(
        // sql statement to execute
        string sql, 
        // E.g CommandType.StoredProcedure
        CommandType commandType, 
        // this holds the logic to create an instance of T from the data reader
        Func<IDbDataReader, T> populator, 
        // parameters required to the sql
        params IDbDataParameter[] parameters)
    {
        using(var con = new SqlConnection(_connectionString))
        {
            using(var cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                con.Open();
                using(var reader = cmd.ExecuteReader())
                {
                    return populator(reader); 
                }
            }
        }
    } 
