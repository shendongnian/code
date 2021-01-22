    new GenericDelegate(DoSomething).BeginInvoke(DoSomethingComplete);
    
    void DoSomethingComplete(IAsyncResult ar)
    {
        ((GenericDelegate)((AsyncResult)ar).AsyncDelegate)).EndInvoke();
    }
