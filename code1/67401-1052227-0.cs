    private void RunThread()
    {
        while(!this.flag.WaitOne(TimeSpan.FromMilliseconds(100)))
        {
            // ...
        }
    }
