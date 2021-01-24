    Task parent = Task.Factory.StartNew(() =>
    {
        Console.WriteLine("Parent task starting...");
        Task child = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Child task starting...");
            Thread.Sleep(1000);
            Console.WriteLine("Child task completed!");
        }, TaskCreationOptions.AttachedToParent, default(CancellationToken), TaskScheduler.Default);
    }, TaskCreationOptions.None, default(CancellationToken), TaskScheduler.Default);
    parent.Wait();
