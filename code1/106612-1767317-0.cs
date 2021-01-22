    private T CreateCommand<T>(string query, Func<SqlCeCommand, T> func)
    {
        var connString = GetLocalConnectionString();
        using (var cn = new SqlCeConnection(connString))
        {
            cn.Open();
            using (var cmd = cn.CreateCommand())
            {
                cmd.CommandText = query;
                return func(cmd);
            }
        }
    }
    private void CreateCommand(string query, Action<SqlCeCommand> action)
    {
        CreateCommand<object>(query, cmd => 
        {
            action(cmd);
            return null;
        });
    }
    internal void RunNonQuery(string query)
    {
        CreateCommand(query, cmd => cmd.ExecuteNonQuery());
    }
    internal int RunScalar(string query)
    {
        return CreateCommand(query, cmd => 
            int.Parse(cmd.ExecuteScalar().ToString()));
    }    
