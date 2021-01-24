    AutoResetEvent autoResetEvent = new AutoResetEvent(true);
    public void StartSomeMethod()
    {
        if(autoResetEvent.WaitOne(0))
        {
          
        }
    }
    public void SomeMethod()
    {
        autoResetEvent.Set();
    }
