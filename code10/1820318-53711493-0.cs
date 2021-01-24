    public class ExpectedException : Exception
    {
        public int Value { get; }
        public ExpectedException(int value, string message) : base(message)
        {
            Value = value;
        }
    }
    private async Task<int> AsyncMethod1(int value)
    {
        await Task.Delay(500);
        return value + 1;
    }
    private async Task<int> AsyncMethod2(int value)
    {
        await Task.Delay(500);
        if (value % 3 == 0)
            throw new ExpectedException(value, "Expected exception");
        else
            return value * 2;
    }
    private async Task DoJobAsync(int value)
    {
        var i1 = await AsyncMethod1(value);
        var i2 = await AsyncMethod2(i1);
        Console.WriteLine($"The result is {i2}");
    }
    private async Task RunTasksAsync()
    {
        const int tasksCount = 10;
        var tasks = Enumerable.Range(0, tasksCount)
            .Select(async i =>
            {
                try
                {
                    await DoJobAsync(i);
                }
                catch (ExpectedException exception)
                {
                    Console.WriteLine($"Caught an exception while executing task, task data: {exception.Value}");
                }
            })
            .ToList();
        await Task.WhenAll(tasks);
        Console.WriteLine("All tasks finished");
    }
