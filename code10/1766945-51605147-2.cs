    static Dictionary<string,object> _dictionary = new Dictionary<string, object>();
            public List<TResult> ExecuteStoredProcedureWithLock<TResult>(string storedProcedureName, object parameters) where TResult : new()
            {
                lock (_dictionary)
                {
                    if (_dictionary.ContainsKey(storedProcedureName) == false)
                    {
                        _dictionary.Add(storedProcedureName,new object());
                    }
                }
    
                lock (_dictionary[storedProcedureName])
                {
                    return ExecuteStoredProcedure<TResult>(storedProcedureName, parameters);
                }
            }
