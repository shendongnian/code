    static void main(string[] args)
    {
        Method1();
        Console.WriteLine("Suddenly here")
    }
    
    [DebuggerStepThrough, DebuggerStepperBoundary]
    private static void Method1()
    {
        Method2();
    }
    
    private static void Method2()
    {
        'Skipped.
    }
