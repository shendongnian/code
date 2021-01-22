    // Sample for the Environment.StackTrace property
    using System;
    class Sample
    {
        public static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += 
              new UnhandledExceptionEventHandler(UnhandledExceptions);
            Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);
            throw new Exception("Fatal Error");
        }
        static void UnhandledExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            string source = "SOTest";
            if (!System.Diagnostics.EventLog.SourceExists(source))
            {
                System.Diagnostics.EventLog.CreateEventSource(source, "Application");
            }
            System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
            log.Source = source;
            log.WriteEntry(e.ExceptionObject.ToString(), 
                           System.Diagnostics.EventLogEntryType.Error);
        }
