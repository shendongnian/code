    private static void Write() {
        if (!Monitor.TryEnter(LogManager._WriteLock, 2000)) {
           // Do whatever you want when you can't get a lock in time
        } else {
          try {
             string message = (string)LogManager._SynchronizedQueue.Dequeue();
             if (message != null) {
                 // Your file writing logic here
    	     }
          }
          finally {
            Monitor.Exit(LogManager._WriteLock);
          }
        }
    }
