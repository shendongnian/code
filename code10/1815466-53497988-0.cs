        static async Task Main(string[] args)
        {
            var results = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(Enumerable.Range(0, 100), async index =>
            {
                var res = await DoAsyncJob(index);
                results.TryAdd(index.ToString(), res);
            });  
            Console.WriteLine($"Items in dictionary {results.Count}");
        }
        static async Task<int> DoAsyncJob(int i)
        {
            await Task.Delay(100);
            return i * 10;
        }
