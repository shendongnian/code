    public static async Task DoWorkLoads(List<IPAddress> addresses)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 50
                         };
    
       var block = new ActionBlock<IPAddress>(TestSocket, options);
    
       foreach (var ip in addresses)
          block.Post(ip);
    
       block.Complete();
       await block.Completion;
    
    }
