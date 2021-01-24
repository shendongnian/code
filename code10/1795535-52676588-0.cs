    public async static void Main(string[] args)
    {
       var task1 = GetIntegerAsync();
       var task2 = GetAnotherIntegerAsync();
       var result = await Task.WhenAll(new[] {task1, task2});
       foreach(var res in results)
       {
         // show a different message depending on res.isFailed
       }
    }
    private static async Task<(int result, bool isFailed)> GetIntegerAsync()
    {
       try
       {
         await Task.Delay(1000).ConfigureAwait(false);
         return (10, false);
       }
       catch(Exception)
       {
         return (default(int), true);
       }
    }
    private static async Task<(int result, bool isFailed)> GetAnotherIntegerAsync()
    {
       try
       {
         await Task.Delay(600).ConfigureAwait(false);
         throw new Exception("Something bad happened...");
       }
       catch(Exception)
       {
         return (default(int), true);
       }
    }
    
