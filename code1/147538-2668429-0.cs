    [Conditional("DEBUG")] 
    public static void Assert(bool condition) 
    { 
        if (Debugger.IsAttached) 
        { 
            Debug.Assert(condition); 
        } 
        else 
        { 
            throw new SomeException(); 
        } 
    }
 
