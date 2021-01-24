    public static Task StartProcess(double myvariable)
    {
       tokenSource = new CancellationTokenSource();
       CancellationToken token = tokenSource.Token;
    
       return Task.Factory.StartNew(() =>
       {
          while (true)
          {
             //Do some work with myvariable
    
             if (token.IsCancellationRequested)
             {
                token.ThrowIfCancellationRequested();
                break;
             }
          }
       }, token);
    }
    public async Task ExecuteProcess(double myvariable)
    {
       try
       {
          await StartProcess(myvariable);
       }
       catch (OperationCanceledException ex)
       {
          Console.WriteLine("Process Thread Canceled");
       }
       catch (Exception ex)
       {
          Console.WriteLine("ERROR");
       }
    }
