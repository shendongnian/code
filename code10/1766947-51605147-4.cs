    static Dictionary<string, object> _dictionary = new Dictionary<string, object>();
    public List<TResult> ExecuteStoredProcedureWithLock<TResult>(string storedProcedureName, object parameters) where TResult : new()
    {
        lock (_dictionary)
        {
            if (_dictionary.ContainsKey(storedProcedureName) == false)
            {
                _dictionary.Add(storedProcedureName, new object());
            }
        }
    
        lock (_dictionary[storedProcedureName])
        {
            return ExecuteStoredProcedure<TResult>(storedProcedureName, parameters);
        }
    }
    
    public async Task<List<TResult>> ExecuteStoredProcedureWithLockAsync<TResult>(string storedProcedureName, object parameters, CancellationToken cancellationToken) where TResult : new()
    {
        lock (_dic)
        {
            if (_dic.ContainsKey(storedProcedureName) == false)
            {
                _dic.Add(storedProcedureName, new object());
            }
        }
        List<TResult> result = new List<TResult>();
        Monitor.Enter(_dic[storedProcedureName]);
        try
        {
            result = await ExecuteStoredProcedureAsync<TResult>(storedProcedureName, parameters, cancellationToken);
        }
        finally
        {
            Monitor.Exit(_dic[storedProcedureName]);
        }
        return result;
    }
