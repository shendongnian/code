    int count = 0;
    try
    {
        var usersToProcess = new List<User>();
        const int n = 10;
        var processes = new List<Task>();
        for (int i = 0; i<n; ++i)
        {
            int j = i;
            processes.Add(Task.Run(() =>
            {
                Thread.Sleep(1000);
                Interlocked.Increment(ref count);
                //throw an exception in task 2 and 5
                if (j == 1 || j == 4)
                    throw new Exception("...");
            }));
        }
        await Task.WhenAll(processes); // await all here
    }
    catch (Exception ex)
    {
        Console.WriteLine(count); //will always print 10
    }
    Console.WriteLine(count); //will always print 10
