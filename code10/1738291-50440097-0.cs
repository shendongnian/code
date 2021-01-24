    async Task Func1(int n)
    {
        Console.WriteLine($"Func1-{n} started");
        if ((n % 3) == 1)
            _tasks.Add(Func2(n));
        await Task.Delay(2000);
        Console.WriteLine($"Func1-{n} complete");
    }
