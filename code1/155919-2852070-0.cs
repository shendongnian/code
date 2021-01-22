    private static Mutex _mutex;
    
    [STAThread]
    static void Main (string[] args)
    {
          // Ensure only one instance runs at a time
          _mutex = new Mutex (true, "MyMutexName");
          if (!_mutex.WaitOne (0, false))
          {
                return;
          }
    }
