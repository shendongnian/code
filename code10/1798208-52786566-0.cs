    public static TResult UseDisposable<TDisposable, TResult>(TDisposable disposable, Func<TDisposable, TResult> function)
        where TDisposable : IDisposable
    {
        using (disposable)
        {
            return function(disposable);
        }
    }
