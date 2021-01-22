    [Test]
    public void MyTest() 
    {
        var reference = TestInternal();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Assert.IsNull(reference.Target);
    }
    
    private WeakReference TestInternal()
    {
       var service = new Service();
       // Do things with service that might cause a memory leak...
       return new WeakReference(service, true);
       // Service should have gone out of scope about now, 
       // so the garbage collector can clean it up
    }
