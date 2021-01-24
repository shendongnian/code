    private static object lock = new object();
    private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (!Monitor.TryEnter(lock))
            return;
        try
        {
          SomeMethod(); 
        }
        finally
        {
          Monitor.Exit(lock);
        }
    }
    
