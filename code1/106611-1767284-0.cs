    static void PerformQuery(string connectionString, string command,
          Action<SqlCeCommand> action)
    { //TODO: sanity checks...
        using(SqlCeConnection conn = new SqlCeConnection(connectionString))
        using(SqlCeCommand cmd = conn.CreateCommand()) {
            cmd.CommandText = command;
            conn.Open();
            action(cmd);
        }
    }
    internal void RunNonQuery(string query)
    {
        string connString = GetLocalConnectionString();
        PerformQuery(connString, query, cmd => cmd.ExecuteNonQuery());
    }  
    internal int RunScalar(string query)  
    {
        int result = 0;
        string connString = GetLocalConnectionString();
        PerformQuery(connString, query,
            cmd => {result = int.Parse(cmd.ExecuteScalar().ToString()); }
        );
        return result;
    }
