    static async Task Main(string[] args)
    {
        await foreach (var num in GetNumbersAsync())
        {
            Console.WriteLine(num);
        }
    }
    private static async IAsyncEnumerable<int> GetNumbersAsync()
    {
        var nums = Enumerable.Range(0, 10);
        foreach (var num in nums)
        {
            await Task.Delay(100);
            yield return num;
        }
    }
