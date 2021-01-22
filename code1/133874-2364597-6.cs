    public static FeedCheck{
      int _count = 0;
      static object _consumingSync = new object();
      static Threading.Timer _produceTimer;
      private static void Consume() {
        if (!Monitor.TryEnter(_consumingSync)) return;
        try {
          while(_count > 0) {
            // check feed
            Interlocked.Decrement(ref _count);
          }
        }
        finally { Monitor.Exit(_consumingSync); }
      }
      private static void Produce() {
        Interlocked.Increment(ref _count);
        Consume();
      }
      public static void Start() {
        // small risk of race condition here, but not necessarily
        // be bad if multiple Timers existed for a moment, since only
        // the last one will survive.
        if (_produceTimer == null) {
          _produceTimer = new Threading.Timer(
            _ => FeedCheck.Produce(), null, 0, 1000
          );
        }
      }
    }
