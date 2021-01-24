    int count = _tasks.Count;
    while (true)
    {
        await Task.WhenAll(_tasks);
        lock (_tasks)
        {
            if (count == _tasks.Count)
            {
                Console.WriteLine("All Tasks complete");
                break;
            }
            count = _tasks.Count;
            Console.WriteLine("Some Tasks complete");
        }
    }
    async Task Func1(int n)
    {
        Console.WriteLine($"Func1-{n} started");
        await Task.Delay(2000);
        if ((n % 3) == 1)
        {
            lock (_tasks)
            {
                _tasks.Add(Func2(n));
            }
        }
        Console.WriteLine($"Func1-{n} complete");
    }
