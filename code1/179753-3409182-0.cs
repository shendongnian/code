    static readonly object key = new object();
    
    void TimerHandler(object sender, TimerElapsedEventArgs e)
    {
      if(Monitor.TryEnter(key))
      {
        try
        {
          //do your stuff
        }
        finally
        {
          Montitor.Exit(key);
        }
      }
    }
