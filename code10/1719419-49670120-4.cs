    var block = new ActionBlock<IpAddress>(
        MyMethodAsync,
        new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 50 });
    
    foreach (var ip in IpList)
    {
        block.Post(ip );
    }
    
    block.Complete();
    await block.Completion;
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
