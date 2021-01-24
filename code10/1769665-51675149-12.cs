    var cts=new CancellationTokenSource(60000); //Timeout in 1 minute
    var options = new ExecutionDataflowBlockOptions
         {
            MaxDegreeOfParallelism = 20,
            CancellationToken=cts.Token
         };
    var block=new ActionBlock<string>(file => SomeSlowFileProcessing(file), options);
    //.....
    try
    {
        await block.Completion;
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Timed out!");
    }
    
