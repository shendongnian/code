    static void Main(string[] args)
    {
          new MethodInvoker(FireAway).BeginInvoke(null, null);
          Console.WriteLine("Main: " + Thread.CurrentThread.ManagedThreadId);
          
          Thread.Sleep(5000);
    }
    private static void FireAway()
    {
        Thread.Sleep(2000);
          
        Console.WriteLine("FireAway: " + Thread.CurrentThread.ManagedThreadId );  
    }
