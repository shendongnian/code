        public static void Main()   
        {   
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);
            //some code here....
        }   
  
        /// <summary>
        /// Occurs when you have an unhandled exception
        /// </summary>
        public static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)   
        { 
            //here's how you get the exception  
            Exception exception = (Exception)e.ExceptionObject;  
            //bail out in a tidy way and perform your logging
        }
