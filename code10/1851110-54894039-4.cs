    public static async Task Main(string[] args)
    {
         IList<Task> tasks = new List<Task>();
        tasks.Add(TestAsync(0));
        tasks.Add(TestAsync(1));
        tasks.Add(TestAsync(2));
        tasks.Add(TestAsync(3));
        tasks.Add(TestAsync(4));
        tasks.Add(TestAsync(5));
        var result = Task.WaitAny(tasks.ToArray());
        Console.WriteLine("returned task id is {0}", result);
        ///do other operations where
        //before exiting wait for other tasks so that your tasks won't get cancellation signal
        await Task.WhenAll(tasks.ToArray());
    }
    public static async Task TestAsync(int i)
    {
        Console.WriteLine("Staring to wait" + i);
        await Task.Delay(new Random().Next(1000, 10000));
        Console.WriteLine("Task finished" + i);
    }
