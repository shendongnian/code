    public static void UseDisposable<TDisposable>(TDisposable disposable, Action<TDisposable> action)
        where TDisposable : IDisposable
    {
        using (disposable)
        {
            action(disposable);
        }
    }
    public static async Task UseDisposable<TDisposable, TResult>(TDisposable disposable, Func<TDisposable, Task> action)
        where TDisposable : IDisposable
    {
        using (disposable)
        {
            await action(disposable);
        }
    }
