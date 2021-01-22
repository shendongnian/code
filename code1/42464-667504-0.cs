    ManualResetEvent Event1 = new ManualResetEvent(false);
    ManualResetEvent Event2 = new ManualResetEvent(false);
    
    void SomeMethod()
    {
        WaitHandle[] handles = {Event1, Event2};
        AsynchronousCall1();
        AsynchronousCall2();
        int index = WaitHandle.WaitAny(handles);
        // if index == 0, then Event1 was signaled.
        // if index == 1, then Event2 was signaled.
    }
    
    void AsyncProc1()
    {
        // does its thing and then
        Event1.Signal();
    }
    
    void AsyncProc2()
    {
        // does its thing and then
        Event2.Signal();
    }
