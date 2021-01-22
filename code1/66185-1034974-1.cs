    for(int i=0; i<10; i++)
    {
        var initializeme = expression
                             ? SomeMethodReturningString()
                             : string.Empty; 
        Console.WriteLine(initializeme);
    }
