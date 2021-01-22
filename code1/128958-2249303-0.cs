    ComplexBuilder cb = new ComplexBuilder();
    try
    {
        cb.AddOperation(...);  // Once building starts,
        cb.AddOperation(...);  // it's not safe to use cb
        cb.AddOperation(...);
    }
    catch (SpecificException ex)
    {
        cb.Cleanup();          // until it's cleaned up
    }
    
    // Now safe to access cb, whether or not an exception was thrown
