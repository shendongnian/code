    using System.Collections.Async;
    
    class Program
    {
        private async Task SQLBulkLoader() {
    
            await indicators.file_list.ForEachAsync(async fileListObj =>
            {
                //Doing Stuff
            });          
        }
    
        static void Main(string[] args)
        {
            Program worker = new Program();
            worker.SQLBulkLoader().GetAwaiter().GetResult();
        }
    }
