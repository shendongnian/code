    public static async Task DoWorkLoads(List<Something> results)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 2
                         };
    
       var block = new ActionBlock<int>(MyMethodAsync, options);
    
       foreach (var item in list)
          block.Post(item );
    
       block.Complete();
       await block.Completion;
    
    }
    ...
    
    public async Task MyMethodAsync(int i)
    {       
        await Task.Delay(10 * 1000);
    }
