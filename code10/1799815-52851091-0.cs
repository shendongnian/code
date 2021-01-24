    var task = Task.Factory.StartNew(() =>
    {
        System.Console.WriteLine("Parent starting..");
        var childTasks = new Task[10];
        for (var i = 0; i < 10; ++i)
        {
            childTasks[i] = Task.Factory.StartNew(obj =>
            {
                System.Console.WriteLine($"\tChild #{obj} starting...");
                Thread.Sleep(1000);
                System.Console.WriteLine($"\tChild #{obj} done..");
            }, i, TaskCreationOptions.AttachedToParent);
        }
    
        Task.WaitAll(childTasks);
    });
    
    task.Wait();
    System.Console.WriteLine("Parent done..");
