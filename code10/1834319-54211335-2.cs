    public T Execute<T>(string sql, CommandType commandType, Func<IDbCommand, T> function, params IDbDataParameter[] parameters)
    {
        using (var con = new TConnection())
        {
            con.ConnectionString = _ConnectionString;
            using (var cmd = new TCommand())
            {
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.CommandType = commandType;
                if (parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                con.Open();
                return function(cmd);
            }
        }
    }
