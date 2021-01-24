    public static async Task DoWorkLoads(List<Proxy> results)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 50
                         };
    
       var block = new ActionBlock<Proxy>(CheckUrlAsync, options);
    
       foreach (var proxy in results)
       {
          block.Post(proxy);
       }
    
       block.Complete();
       await block.Completion;
    }
    
