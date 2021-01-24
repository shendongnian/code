    public static TResult Using<TDisposable, TResult>(TDisposable disposable, Func<TDisposable, TResult> func) 
        where TDisposable : IDisposable
    {
        using (disposable)
        {
            return func(disposable);
        }
    }
