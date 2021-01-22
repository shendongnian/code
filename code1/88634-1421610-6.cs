    AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
    {
        Console.Error.WriteLine("Unhandled exception: " + args.ExceptionObject);
        Environment.Exit(1);
    }
