    private static ActionMonitor _actionMonitor;
    
    static void Main(string[] args)
    {
        _actionMonitor = new ActionMonitor();
        _actionMonitor.OnActionStarted();
        _actionMonitor.ExecuteAfterAction(Foo1);
        _actionMonitor.ExecuteAfterAction(Foo2);
        _actionMonitor.OnActionEnded();
        Console.ReadLine();
    }
    private static void Foo1()
    {
        _actionMonitor.OnActionStarted();
        _actionMonitor.ExecuteAfterAction(Foo3);
    }
    private static void Foo2()
    {
        
    }
    private static void Foo3()
    {
        
    }
