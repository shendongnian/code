    public static void Main()
    {
      var are = new AutoResetEvent(false);
      var thread = new Thread(
        () =>
        {
          while (true)
          {
            Thread.Sleep(1000);
            are.Set(); // worker thread signals the event
          }
        });
      thread.Start();
      while (are.WaitOne()) // main thread waits for the event to be signaled
      {
        Console.WriteLine(DateTime.Now);
      }
    }
