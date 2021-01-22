    void Dispose()
    {
      GC.SuppressFinalize(this);
    }
    #if DEBUG
    ~MyClass()
    {
      Debug.Fail("Dispose was not called.");
    }
    #endif
