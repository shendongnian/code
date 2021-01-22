    public void Foo()
    {
        var beginTicks = 0L;
        var endTicks = 0L;
        NativeMethods.QueryPerformanceCounter(ref beginTicks);
        
        // Do stuff
        
        NativeMethods.QueryPerformanceCounter(ref endTicks);
        this.Counter.IncrementBy(endTicks - beginTicks);
        this.BaseCounter.Increment();
    }
