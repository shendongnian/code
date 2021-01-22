    public TResult ExecuteAndLogOnError(Func<TResult> func)
    {
        try
        {
            return func();
        }
        catch(Exception ex)
        {
           // logging ...
        }
    }
