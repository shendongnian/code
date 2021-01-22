    static object _sync = new object();
    // ..
    var thread = new Thread(_ => {
      lock(_sync) {
        MyFunctions.CalculateTotal(a, b);
        Monitor.Wait(_sync);
      }
    }).Start(null);
    if (!Monitor.TryEnter(_sync, 5000) {
      MyFunctions.ThreadExit();
      thread.Abort();
    }
    else {
      try {
        Monitor.Pulse(_sync);
      }
      finally {
        Monitor.Exit(_sync);
      }
    }
