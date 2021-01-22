    static class EntryPoint {
        [MTAThread]
        static void Main() {
            // Add Global Exception Handler
            AppDomain.CurrentDomain.UnhandledException += 
                new UnhandledExceptionEventHandler(OnUnhandledException);
     
            Application.Run(new Form1());
        }
     
        // In CF case only, ALL unhandled exceptions come here
        private static void OnUnhandledException(Object sender, 
            UnhandledExceptionEventArgs e) {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null) {
                // Can't imagine e.IsTerminating ever being false
                // or e.ExceptionObject not being an Exception
                SomeClass.SomeStaticHandlingMethod(ex, e.IsTerminating);
            }
        }
    }
