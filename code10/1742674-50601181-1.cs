    public delegate T ParamsDelegate<T>(params Object[] args);
            
    public T GetValue<T>(ParamsDelegate<T> f, params Object[] args)
    {
        return f(args);            
    }
    // 0 passed argument values.  
    String s0 = GetValue(args => "Bob Smith");
                        
    // 1 argument.
    String s1 = GetValue(
        args => String.Format("{0} Smith", args),
        "Bob"
        );
    
    // 2 arguments.            
    String s2 = GetValue(
        args => String.Format("{0} {1}", args),
        "Bob", "Smith"
        );
