        CancellationTokenSource cts = new CancellationTokenSource();
        List<Task> allTask = new List<Task>();
        for (int i = 0; i < 10000; i++)
        {
            int j = i;
            allTask.Add(Task.Factory.StartNew(() =>
            {
                if (cts.Token.IsCancellationRequested)
                {
                    return;
                }
                cts.Cancel();
                Thread.Sleep(1000);
                Console.WriteLine("I'm doing it");
            }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Current));
        }
        try
        {
            Task.WaitAll(allTask.ToArray());
        }
        catch (AggregateException ex)
        {
            //handle the cancelled tasks here, though you are doing it on purpose...
            Console.WriteLine("One or more tasks were cancelled.");
        }
        Console.WriteLine("Implementation success!");
        Console.ReadKey();
