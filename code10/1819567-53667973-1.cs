    private static object lock = new object();
    private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        bool haveLock = false;
        try
        {
            Monitor.TryEnter(lock, ref haveLock);
            if (haveLock)
            {
                SomeMethod(); 
            }
        }
        finally
        {
            if (haveLock)
            {
                Monitor.Exit(lock);
            }
        }
    }
