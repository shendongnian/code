    // assuming console program, but every application Console, WinForm,
    // Wpf, WindowsService, WebService, WcfService has a similar entry point
    class Program
    {
        // assume log4net logging here, but could as easily be
        // Console.WriteLine, or hand rolled logger
        private static readonly ILog _log = LogManager.GetLogger (typeof (Program));
        static void Main (string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += 
                CurrentDomain_UnhandledException;
        }
        private static void CurrentDomain_UnhandledException (
            object sender, 
            UnhandledExceptionEventArgs e)
        {
            _log.
                Fatal (
                string.Format (
                "Unhandled exception caught by " +
                "'CurrentDomain_UnhandledException'. Terminating program.", 
                e.ExceptionObject);
        }
    }
