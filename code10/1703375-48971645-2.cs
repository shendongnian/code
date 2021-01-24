    static async Task TestFun(CancellationToken ct) {
        Console.WriteLine("start");
        await Task.Delay(4000, ct);
        Console.WriteLine("Action is end");
    }
    Task task = TestFun(token);
    // no need for task.Start() here - task is already started
    source.CancelAfter(100);
    Console.ReadLine();
