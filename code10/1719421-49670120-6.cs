    public static async Task DoWorkLoads(List<IPAddress> addresses)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 50
                         };
       var block = new ActionBlock<IPAddress>(MyMethodAsync, options);
    
       foreach (var ip in addresses)
          block.Post(ip);
    
       block.Complete();
       await block.Completion;
    
    }
    ...
    public async Task MyMethodAsync(IpAddress ip)
    {
       
        try
        {
            var record = await client.Query(ip);
            // note this is not thread safe best to lock it
            results.Add(record);
        }
        catch (Exception)
        {
            // note this is not thread safe best to lock it
            failed.Add(ip);
        }
    }
