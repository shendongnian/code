    public async Task AsyncAwait()
    {
        await DoAsync();
        DoSomethingElse();
    }
    public async Task Continuation()
    {
        await DoAsync().ContinueWith(_ => DoSomethingElse());
    }
    public Task DoAsync() => Task.Delay(TimeSpan.FromSeconds(1));
    public void DoSomethingElse()
    {
        //More Work
    }
