    public Task<TResult> Enqueue<TResult>(Func<TResult> func)
    {
        var stdPromiseXD = new TaskCompletionSource<TResult>();
        // the lambda is a callable object with signature void(void)
        works.Enqueue(() =>
        {
            try
            {
                stdPromiseXD.SetResult((TResult)func());
            }
            catch (Exception ex)
            {
                stdPromiseXD.SetException(ex);
            }
        });
        // return the Task which equals std::future in CPP
        return stdPromiseXD.Task;
    }
    public Task Enqueue(Action action)
    {
        return Enqueue<object>(() =>
        {
            action();
            return null;
        });
    }
