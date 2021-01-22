    private T TimeoutFileAction<T>(Func<T> func)
    {
        var started = DateTime.UtcNow;
        while ((DateTime.UtcNow - started).TotalMilliseconds < 2000)
        {
            try
            {
                return func();                    
            }
            catch (System.IO.IOException exception)
            {
                //ignore, or log somewhere if you want to
            }
        }
        return default(T);
    }
