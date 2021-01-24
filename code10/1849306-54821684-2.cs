    public static async Task DoWorkLoads(List<IPAddress> addresses)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 50 // limit here
                         };
    
       var block = new ActionBlock<SomeObject>(MyMethodAsync, options);
    
       foreach (var ip in addresses)
          block.Post(ip);
    
       block.Complete();
       await block.Completion;
    
    }
    
    ...
    
    public async Task MyMethodAsync(SomeObject obj)
    {
        // await something here
    }
