    static void Main()
    {
        AppDomain.CurrentDomain.AssemblyLoad += AssemblyLoad;
        LogCurrent("before");
        AnotherMethod();
        LogCurrent("after");
    }
    static void AnotherMethod()
    {
        new WebClient().BaseAddress = "http://foo"; // to force stuff to happen
    }
    static void LogCurrent(string caption)
    {
        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            Console.WriteLine(caption + ": " + asm.FullName);
        }
    }
    static void AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    {
        Console.WriteLine("Loaded: " + args.LoadedAssembly.FullName);
    }
