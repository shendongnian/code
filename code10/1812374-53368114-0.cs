    // use async all the way down
    static async Task Main(string[] args)
    {
       // using using using
       using (var tokenSource2 = new CancellationTokenSource())
       {
          try
          { 
             var task = DoAsync(tokenSource2.Token);
             // test cancel
             tokenSource2.Cancel();
             // await anything you need.
             await Task.WhenAll(task);  
          }
          // catch CanceledException
          catch (OperationCanceledException)
          {
             Console.WriteLine("Canceled");
          }
          // notice we get normal exceptions and not aggregates 
          catch (Exception e)
          {
             Console.WriteLine(e.Message);
          }    
       }   
       Console.ReadKey();
    }
    
    private static async Task DoAsync(CancellationToken token)
    {
       // pass your toke in to anything that needs it
       await Task.Delay(10000,token).ConfigureAwait(true);
       token.ThrowIfCancellationRequested(); 
    }
