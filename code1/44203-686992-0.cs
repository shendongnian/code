    public MyClass : IDisposable
    {
    
    IEventLogger _eventLogger;
    
    public MyClass() : this(EventLogger.CreateDefaultInstance())
    {
    }
    
    public MyClass(IEventLogger eventLogger)
    {
        _eventLogger = eventLogger;
    }
    
    // IDisposable stuff...
    
    #if DEBUG
    ~MyClass()
    {
        _eventLogger.LogError("MyClass.Dispose() was not called");
    }
    #endif
    
    }
