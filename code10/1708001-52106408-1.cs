    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
                await GetAllAsync().ForEachAsync((x) => Console.WriteLine(x)));
            Thread.Sleep(4000);
        }
        static IAsyncEnumerable<string> GetAllAsync()
        {
            var something = new[] { 1, 2, 3 };
            return something
                .Select((x) => GetAsync(x).Result)
                .ToAsyncEnumerable();
        }
        static async Task<string> GetAsync(int item)
        {
            await Task.Delay(1000); // heavy
            return "got " + item;
        }
    }
