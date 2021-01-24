    private static ConcurrentDictionary<string, object> StatementFuncCache = new ConcurrentDictionary<string, object>();
    public static Func<TOriginal, object> GetOrCreateNewStatementFor<TOriginal>(ISet<string> fields)
    {
        var key = $"{typeof(TOriginal).Name} {string.Join(",", fields.OrderBy(x => x))}";
        var func = StatementFuncCache.GetOrAdd(key, _ => CreateNewStatementFor<TOriginal>(fields));
        return (Func<TOriginal, object>)func;
    }
