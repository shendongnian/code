    AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs ar)
    {
         Exception e = (Exception)ar.ExceptionObject;
         Console.WriteLine("Unhandled exception: " + e);
         Environment.Exit(1);
    };
