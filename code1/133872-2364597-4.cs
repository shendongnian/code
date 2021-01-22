    public static FeedCheck{
      int _count = 0;
      static object _sync = new object();
      public static void Consume() {
        if (Monitor.TryEnter(_sync)) {
           while(_count > 0) {
             // check feed
             Interlocked.Decrement(ref _count);
           }
        }
      }
      public static void Produce() {
        Interlocked.Increment(ref _count);
        Consume();
      }
    }
