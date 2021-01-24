    static Task OneAsync()
    {
        async Task Awaited(Task t)
        {
            await t;
            Console.WriteLine("OneAsync: End");
        }
        Console.WriteLine("OneAsync: Start");
        var task = TwoAsync();
        if (task.Status != TaskStatus.RanToCompletion)
            return Awaited(task);
        Console.WriteLine("OneAsync: End");
        return task; // could also have used Task.CompletedTask
    }
