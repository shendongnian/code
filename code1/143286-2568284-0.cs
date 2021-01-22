    ManualResetEvent manualResetEvent = new ManualResetEvent(false);
    byte b;
    public byte Function1()
    {
        // new thread starting in Function2;
        manualResetEvent.WaitOne();
        return b;
    }
    public void Function2()
    {
        // do some thing
        b = 0;
        manualResetEvent.Set();
    }
