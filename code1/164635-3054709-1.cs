    public void Delete(string application, string key)
    {
        ExecAction(() => Settings.Delete(application, key));
    }
    public object Get(string application, string key, int? expiration)
    {
        return ExecFunc(() => Settings.Get(application, key, expiration));
    }
    // ...
    public TResult ExecFunc<TResult>(Func<TResult> func)
    {
        try
        {
            return func();
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }
