    Console.WriteLine( Assembly.GetEntryAssembly().Location );
    Console.WriteLine( new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath );
    Console.WriteLine( Assembly.GetEntryAssembly().Location );
    Console.WriteLine( Environment.GetCommandLineArgs()[0] );
    Console.WriteLine( Process.GetCurrentProcess().MainModule.FileName );
