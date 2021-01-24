    static async Task MainAsync()
    {
        var list = new List<IAction>();
        for (var i = 0; i < 200; i++) list.Add(new LongAction());
        for (var i = 0; i < 200; i++) list.Add(new MediumAction());
        for (var i = 0; i < 200; i++) list.Add(new ShortAction());
        Console.WriteLine("Sorting...");
        list.Sort((x, y) => y.Size.CompareTo(x.Size));
        int totalTasks = 0;
            
        int degreeOfParallelism = 20;
        var swSync = Stopwatch.StartNew();
        using (SemaphoreSlim semaphore = new SemaphoreSlim(degreeOfParallelism))
        {
            foreach (IAction action in list)
            {
                semaphore.Wait();
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        Console.WriteLine($"{DateTime.Now:HH:mm:ss}: Starting action {action.GetType().Name} on thread {Thread.CurrentThread.ManagedThreadId}");
                        var sw = Stopwatch.StartNew();
                        action.Execute();
                        sw.Stop();
                        Console.WriteLine($"{DateTime.Now:HH:mm:ss}: Finished action {action.GetType().Name} in {sw.ElapsedMilliseconds}ms on thread {Thread.CurrentThread.ManagedThreadId}");
                    }
                    finally
                    {
                        totalTasks++;
                        semaphore.Release();
                    }
                });
            }
            // Wait for remaining tasks....
            while (semaphore.CurrentCount < 20)
            { }
            swSync.Stop();
            Console.WriteLine($"Done in {swSync.ElapsedMilliseconds}ms");
            Console.WriteLine("Performed total tasks: " + totalTasks);
        }
    }
