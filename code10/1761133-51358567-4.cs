    var pollTask = Task.Run(async () => 
     { 
        while (processTask) 
        {
          wToken.ThrowIfCancellationRequested();
          connectionPool.PollEvents();
          await Task.Delay(configLoader.config.connectionPollDelay, wtoken.Token);
        }
      keepRunning = false;
    }, wtoken.Token);
    try 
    {
         pollTask.Wait(wToken);
    }
    catch( AggregateException ex )
    {
        // Handle exception
    }
