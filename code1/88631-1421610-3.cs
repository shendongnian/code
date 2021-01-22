    AppDomain.CurrentDomain.UnhandledException
        += delegate(object sender, UnhandledExceptionEventArgs args)
        {
            var exception = Exception e = (Exception) args.ExceptionObject;
            Console.WriteLine("Unhandled exception: " + exception);
            Environment.Exit(1);
        }
