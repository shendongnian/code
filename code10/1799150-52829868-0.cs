    static Task<string> FooAsync(List<int> data)
    {
        var tcs = new TaskCompletionSource<string>();
        Action action = () => Foo(data, result => tcs.SetResult(result));
        // If Foo isn't blocking, we can execute it in the ThreadPool:
        Task.Run(action);
        // If it is blocking for some time, it is better to create a dedicated thread
        // and avoid starving the ThreadPool. Instead of 'Task.Run' use:
        // Task.Factory.StartNew(action, TaskCreationOptions.LongRunning);
        return tcs.Task;
    }
