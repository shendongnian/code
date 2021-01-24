    try 
    {
     await Task.Run(async () => 
     { 
        while (processTask) 
        {
          wToken.ThrowIfCancellationRequested();
          connectionPool.PollEvents();
          await Task.Delay(configLoader.config.connectionPollDelay, wtoken.Token);
        }
      keepRunning = false;
    }, wtoken.Token);
    }
    catch( Exception ex )
    {
        // Handle exception
    }
