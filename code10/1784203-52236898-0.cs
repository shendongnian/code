    private AsyncLocal<string> _scope = new AsyncLocal<string>();
    private async Task Method1()
    {
        _scope.Value = "method 1";
        // ... other awaited calls
        await DoWork();
    }
    private async Task Method2()
    {
        _scope.Value = "method 2";
        // ... other awaited calls
        await DoWork();
    }
    private async Task DoWork()
    {
        Console.WriteLine(_scope.Value);
    }
