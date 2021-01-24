    public TResponse ExecuteAndLog<TResponse>(Guid id, string Name, Func<TResponse> method) where TResponse : class
    {
        try
        {
            Log(id, Name);
            TResponse x = method();
            Log(id, Name);
        }
        catch (Exception ex)
        {
            Log(id, Name);
            throw;
        }
    }
