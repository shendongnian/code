    lock (someObject)
    {
       // Do one thing.
       someDispatcher.Invoke(() =>
       {
          // Do something else.
       }
    }
