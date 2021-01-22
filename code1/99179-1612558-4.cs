    public void Call()
    {
        // Call with int argument 1
        DoSomething(1);
    
        // Call with Func that returns 1
        // It'll never produce the value unless Func is invoked
        DoSomething(new Func<int>(() => 1));
        // Call with Func explicitly invoked
        // In this case the body of the lambda will be executed
        DoSomething(new Func<int>(() => 1).Invoke());
    }
    
    public void DoSomething(object obj)
    {
        
    }
