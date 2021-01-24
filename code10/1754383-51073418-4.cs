    public static async Task Tester()
    {
       var sw = new Stopwatch();
    
       try
       {
          var tasks = Enumerable.Range(0, 100)
                                .Select(x => GetUserMsAsync())
                                .ToArray();
    
          sw.Start();
    
          var results = await Task.WhenAll(tasks);
    
          foreach (var result in results)
          {
             Console.WriteLine(result);
          }
       }
       finally
       {
          sw.Stop();
          Console.WriteLine($"sw : {sw.Elapsed:c}");
       }
    }
