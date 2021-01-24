    static async Task Run()
    {
        var syncContext = new MySyncContext { State = "The Original State" };
        SynchronizationContext.SetSynchronizationContext(syncContext);
        Console.WriteLine("Original:" + SynchronizationContext.Current);
        await Task.Delay(1000).ConfigureAwait(false);
        Console.WriteLine("After Result1:" + SynchronizationContext.Current);
        await Task.Delay(1000);
        Console.WriteLine("After Result2:" + SynchronizationContext.Current);
    }
