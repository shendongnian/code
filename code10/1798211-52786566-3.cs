    public static TResult UseDisposable<TDisposable, TResult>(Func<TDisposable> disposableGenerator, Func<TDisposable, TResult> function)
        where TDisposable : IDisposable
    {
        using (var disposable = disposableGenerator())
        {
            return function(disposable);
        }
    }
    public static async Task<TResult> UseDisposable<TDisposable, TResult>(Func<TDisposable> disposableGenerator, Func<TDisposable, Task<TResult>> function)
        where TDisposable : IDisposable
    {
        using (var disposable = disposableGenerator())
        {
            return await function(disposable);
        }
    }
    public static void UseDisposable<TDisposable>(Func<TDisposable> disposableGenerator, Action<TDisposable> action)
        where TDisposable : IDisposable
    {
        using (var disposable = disposableGenerator())
        {
            action(disposable);
        }
    }
    public static async Task UseDisposable<TDisposable, TResult>(Func<TDisposable> disposableGenerator, Func<TDisposable, Task> action)
        where TDisposable : IDisposable
    {
        using (var disposable = disposableGenerator())
        {
            await action(disposable);
        }
    }
