    public static FeedCheck{
      int _count = 0;
      static object _sync = new object();
      public static void Consume() {
        if (Monitor.TryEnter(_sync)) {
           while(Producer.Count > 0) {
             // check feed
             Interlocked.Decrement(ref _count);
           }
        }
      }
    }
