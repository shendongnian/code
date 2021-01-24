    void AlmostUnrelatedCode()
    {
       var context = _contextFactory.CreateReadOptimized();
       AlmostUnrelatedCode(context);
       context.Dispose();
    }
    
    void AlmostUnrelatedCode(MyDatabase context)
    {
        // Do many, many things with context...
    }
