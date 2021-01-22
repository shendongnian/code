    for(int i=0; i < 10; i++)
    {
        string initializeme = expression ? SomeMethodReturningString() : "";    
        Console.WriteLine(initializeme);    
    }
