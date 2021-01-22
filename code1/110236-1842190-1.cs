    private static void Main(string[] args)
    {
        var domain = AppDomain.CurrentDomain;
        domain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
        domain.ProcessExit += new EventHandler(domain_ProcessExit);
        domain.DomainUnload += new EventHandler(domain_DomainUnload);
    }
    static void MyHandler(object sender, UnhandledExceptionEventArgs args)
    {
        Exception e = (Exception)args.ExceptionObject;
        Console.WriteLine("MyHandler caught: " + e.Message);
    }
    
    static void domain_ProcessExit(object sender, EventArgs e)
    {
    }
    static void domain_DomainUnload(object sender, EventArgs e)
    {
    }
