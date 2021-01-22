    public void MyTest()
    {
        var doneEvent = new ManualResetEvent(false);
    
        myEventRaiser.OnEvent += delegate { doStuff(); doneEvent.Set(); };
        myEventRaiser.RaiseEventInSeparateThread();
        doneEvent.WaitOne();
    
        Assert.That(stuff);
    }
