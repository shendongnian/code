    public async Task DoWorkLoads(List<WorkLoad> workloads)
    {
       var options = new ExecutionDataflowBlockOptions
                         {
                            // add pepper and salt to taste
                            MaxDegreeOfParallelism = 100,
                            EnsureOrdered = false
                         };
       // create an action block
       var block = new ActionBlock<WorkLoad>(MyMethodAsync, options);
    
       // Queue them up
       foreach (var workLoad in workloads)
          block.Post(workLoad );
    
       // wait for them to finish
       block.Complete();
       await block.Completion;
    
    }
    ...
    // Notice we are using the async / await pattern
    public async Task MyMethodAsync(WorkLoad workLoad)
    {
       
        try
        {
            Console.WriteLine("Doing some IO work async);
            await DoIoWorkAsync;
        }
        catch (Exception)
        {
            // probably best to add some error checking some how
        }
    }
