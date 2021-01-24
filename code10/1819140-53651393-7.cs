    private static async IAsyncEnumerable<int> GetNumbersAsync()
    {
        foreach (var num in counter(10))
        {
            await Task.Delay(100);
            yield return num;
        }
    }
    
    private static IEnumerable<int> counter(int count)
    {
        for(int i=0;i<count;i++)
        {
            yield return i;
        }
    }
