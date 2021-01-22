    public void RunAsync<T, TResult>(Func<T, TResult> methodToRunAsync, T arg1, 
        Action<TResult> callback)
    {
        ThreadPool.QueueUserWorkItem(s =>
        {
            TResult result = methodToRunAsync(arg1);
            callback(result);
        });
    }
