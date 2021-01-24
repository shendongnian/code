    public async Task ExampleTask()
    {
        var config = new ExecutionDataflowBlockOptions
        {
            BoundedCapacity = 50,
            MaxDegreeOfParallelism = 15
        };
        var block= new ActionBlock<Guid, object>(TheActualAction, config);
        while(//some condition//)
        { 
            var data=await GetDataFromCosmosDB();
            await block.SendAsync(data);
            //Wait a bit if we want to use polling
            await Task.Delay(...);
        }
        block.Complete();
        await block.Completion;
    }
