    public int ExecuteNonQuery(string sql, CommandType commandType, params IDbDataParameter[] parameters)
    {
        return Execute<int>(sql, commandType, c => c.ExecuteNonQuery(), parameters);
    }
    public bool ExecuteReader(string sql, CommandType commandType, Func<IDataReader, bool> populate, params IDbDataParameter[] parameters)
    {
        return Execute<bool>(sql, commandType, c => populate(c.ExecuteReader()), parameters);
    }
