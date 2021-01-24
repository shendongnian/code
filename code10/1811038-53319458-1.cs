    static async Task Main(string[] args)
    {
        var p1 = StartProcess("--version");
        var p2 = StartProcess("--list-runtimes");
        string[] responses=await Task.WhenAll(p1, p2);
        ...
    }
