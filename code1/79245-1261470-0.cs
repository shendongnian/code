    private ManualResetEvent event1;
    private ManualResetEvent event2;
    public MyResult MyOperation()
    {
       event1 = new ManualResetEvent(false);
       event2 = new ManualResetEvent(false);
        _myCOMObject.AsyncOperation();
    
        event1.WaitOne(-1);
        event2.WaitOne(-1);
    }
    
    private void MyEvent1()
    {
        event1.Set();
    }
    
    private void MyEvent2()
    {
        event2.Set();
    }
