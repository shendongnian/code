    private static async IAsyncEnumerable<int> GetNumbersAsync()
    {
        var nums = Enumerable.Range(0, 10).ToArray();
        foreach (var num in nums)
        {
            await Task.Delay(100);
            yield return num;
        }
    }
