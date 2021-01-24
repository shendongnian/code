    public async void DoWork()
    {
        var task = GetTask();
        task.Start();
        await task;
    }
