    public async Task MethodA()
    {
        // Thread ID 1, 0s passed total
        var a = MethodB(); // takes 1s
        // Thread ID 1, 1s passed total
        await Task.WhenAll(a); // takes 2s
        // Thread ID 5, 3s passed total
        // When the method returns, the SynchronizationContext
        // can change the Thread - see below
    }
    public async Task MethodB()
    {
        // Thread ID 1, 0s passed total
        Thread.Sleep(1000); // simulate blocking operation for 1s
        // Thread ID 1, 1s passed total
        // the await makes MethodB return a Task to MethodA
        // this task is run on the Task ThreadPool
        await Task.Delay(2000); // simulate async call for 2s
        // Thread ID 2 (Task's pool Thread), 3s passed total
    }
