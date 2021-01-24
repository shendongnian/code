    public async void SomeEventHandler()
    {
        Debug.WriteLine($"ManagedThreadID (Dispatcher): {Dispatcher.CurrentDispatcher.Thread.ManagedThreadId}");
        Debug.WriteLine($"ManagedThreadID (MainThread - before Task.Run(Method1)): {Thread.CurrentThread.ManagedThreadId}");
        await Task.Run(() => Method1());
        Debug.WriteLine($"ManagedThreadID (MainThread - after Task.Run(Method1)): {Thread.CurrentThread.ManagedThreadId}");
    }
    private static async Task Method1()
    {
        Debug.WriteLine($"ManagedThreadID (Method1 - before SomeOtherMethodAsync): {Thread.CurrentThread.ManagedThreadId}");
        await SomeOtherMethodAsync();
        Debug.WriteLine($"ManagedThreadID (Method1 - after SomeOtherMethodAsync): {Thread.CurrentThread.ManagedThreadId}");
    }
    private static Task SomeOtherMethodAsync()
    {
        Debug.WriteLine($"ManagedThreadID (SomeOtherMethodAsync): {Thread.CurrentThread.ManagedThreadId}");
        return Task.Delay(1000);
    }
