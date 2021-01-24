    using System.Collections.Async;
    
    class Program
    {
        private async Task SQLBulkLoader() {
    
            await indicators.file_list.ParallelForEachAsync(async fileListObj =>
            {
                ...
                await s.WriteToServerAsync(dataTableConversion);
                ...
            },
            maxDegreeOfParalellism: 3,
            cancellationToken: default);
        }
    
        static void Main(string[] args)
        {
            Program worker = new Program();
            worker.SQLBulkLoader().GetAwaiter().GetResult();
        }
    }
