    public IEnumerable<S> Get<S>(string query, Action<IDbCommand> parameterizer, 
                                 Func<IDataRecord, S> selector)
    {
        using (var conn = new T()) //your connection object
        {
            using (var cmd = conn.CreateCommand())
            {
                if (parameterizer != null)
                    parameterizer(cmd);
                cmd.CommandText = query;
                cmd.Connection.ConnectionString = _connectionString;
                cmd.Connection.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        yield return selector(r);
            }
        }
    }
