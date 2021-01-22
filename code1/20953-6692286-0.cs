    private static T Retry<T>(Func<T> func)
    {
        int count = 3;
        TimeSpan delay = TimeSpan.FromSeconds(5);
        while (true)
        {
            try
            {
                return func();
            }
            catch(SqlException e)
            {
                --count;
                if (count <= 0) throw;
                if (e.Number == 1205)
                    _log.Debug("Deadlock, retrying", e);
                else if (e.Number == -2)
                    _log.Debug("Timeout, retrying", e);
                else
                    throw;
                Thread.Sleep(delay);
            }
        }
    }
    private static void Retry(Action action)
    {
        Retry(() => { action(); return true; });
    }
    // Example usage
    protected static void Execute(string connectionString, string commandString)
    {
        _log.DebugFormat("SQL Execute \"{0}\" on {1}", commandString, connectionString);
        Retry(() => {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(commandString, connection))
                command.ExecuteNonQuery();
        });
    }
    protected static T GetValue<T>(string connectionString, string commandString)
    {
        _log.DebugFormat("SQL Scalar Query \"{0}\" on {1}", commandString, connectionString);
        return Retry(() => { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(commandString, connection))
            {
                object value = command.ExecuteScalar();
                if (value is DBNull) return default(T);
                return (T) value;
            }
        });
    }
