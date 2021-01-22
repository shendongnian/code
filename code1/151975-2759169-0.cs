    class ThreadSafe
    {
      static readonly object _locker = new object();
      static int _val1, _val2;
    
      static void Go()
      {
        lock (_locker)
        {
          if (_val2 != 0) Console.WriteLine (_val1 / _val2);
          _val2 = 0;
        }
      }
    }
