    public TResponse ExecuteAndLog<T1, T2,TResponse>(Guid id, string Name, Func<T1, T2, TResponse> method, T1 arg1, T2 arg2) where TResponse : class
    {
        try
        {
            Log(id, Name);
            TResponse x = method(arg1, arg2);
            Log(id, Name);
            return x;
        }
        catch (Exception ex)
        {
            Log(id, Name);
            throw;
        }
    }
