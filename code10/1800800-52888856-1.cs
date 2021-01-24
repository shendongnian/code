    public static void Method1(CancellationToken token)
    {
          Task.Run(
             async () =>
             {
                while (!token.IsCancellationRequested)
                {
                   // do something
                   await Task.Delay(500, token); // <- await with cancellation
                   Console.WriteLine("Method1");
                }
             }, token);
    }
    public static void Method2(CancellationToken token)
    {
          Task.Run(
             async () =>
                {
                   while (!token.IsCancellationRequested)
                   {
                      // do something
                      await Task.Delay(300, token); // <- await with cancellation
                      Console.WriteLine("Method2");
                   }
                }, token);
    }
    private static void Main(string[] args)
    {
       var source = new CancellationTokenSource();  
       Method1(source.Token);
       Method2(source.Token);
       source.CancelAfter(3000);
       Console.ReadKey();
    }
