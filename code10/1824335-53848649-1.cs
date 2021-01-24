    AutoResetEvent autoResetEvent = new AutoResetEvent(true);
    public void StartSomeMethod()
    {
        if(autoResetEvent.WaitOne(0))
        {
            //start thread
        }
    }
    public void SomeMethod()
    {
        try
        {
            //Do your work
        }
        finally
        {
            autoResetEvent.Set();
        }
    }
