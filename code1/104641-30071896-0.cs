    public class YourService : ServiceBase
    {
      private CancellationTokenSource cts = new CancellationTokenSource();
      private Task mainTask = null;
    
      protected override void OnStart(string[] args)
      {
        mainTask = new Task(Poll, cts.Token, TaskCreationOptions.LongRunning);
        mainTask.Start();
      }
    
      protected override void OnStop()
      {
        cts.Cancel();
        mainTask.Wait();
      }
    
      private void Poll()
      {
        CancellationToken cancellation = cts.Token;
        TimeSpan interval = TimeSpan.Zero;
        while (!cancellation.WaitHandle.WaitOne(interval))
        {
          try 
          {
            // Put your code to poll here.
            // Occasionally check the cancellation state.
            if (cancellation.IsCancellationRequested)
            {
              break;
            }
            interval = WaitAfterSuccessInterval;
          }
          catch (Exception caught)
          {
            // Log the exception.
            interval = WaitAfterErrorInterval;
          }
        }
      }
    }
