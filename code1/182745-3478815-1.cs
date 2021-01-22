    public static void Main()
    {
      var lockObj = new Object();
      int x = 0;
      var thread = new Thread(
        () =>
        {
          while (true)
          {
            lock (lockObj) // blocks until main thread releases the lock
            {
              x++;
            }
          }
        });
      thread.Start();
      while (true)
      {
        lock (lockObj) // blocks until worker thread releases the lock
        {
          x++;
          Console.WriteLine(x);
        }
      }
    }
