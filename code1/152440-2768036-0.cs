    public static class Lookup
    {
      private static readonly ManualResetEvent m_Initialized = new ManualResetEvent(false);
      private static readonly Dictionary<int, string> m_Dictionary = new Dictionary<int, string>();
    
      public static Lookup()
      {
        // Start an asynchronous operation to intialize the dictionary.
        // You could use ThreadPool.QueueUserWorkItem instead of creating a new thread.
        Thread thread = new Thread(() => { Initialize(); });
        thread.Start();
      }
    
      public static string Lookup(int code)
      {
        m_Initialized.WaitOne();
        lock (m_Dictionary)
        {
          return m_Dictionary[code];
        }
      }
    
      private static void Initialize()
      {
        lock (m_Dictionary)
        {
          m_Dictionary.Add(0x0000, "Exclamation Point");
          // Keep adding items to the dictionary here.
        }
        m_Initialized.Set();
      }
    }
