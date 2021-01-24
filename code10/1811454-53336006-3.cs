    static T WaitWithNestedMessageLoop<T>(this Task<T> task)
    {
        var nested = new DispatcherFrame();
        task.ContinueWith(_ => nested.Continue = false, TaskScheduler.Default);
        Dispatcher.PushFrame(nested);
        return task.Result;
    }
