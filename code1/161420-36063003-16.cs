    [StackTraceHidden] // apply this to all methods you want to be omitted in stack traces
    static void Throw()
    {
        throw new SomeException();
    }
    static void Foo()
    {
        Throw();
    }
    static void Main()
    {
        try
        {
            Foo();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }                  
    }      
