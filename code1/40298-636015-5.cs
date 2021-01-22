        using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
        // ...
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            bool rethrow = ExceptionPolicy.HandleException(e.Exception, "Thread Policy");
            if (rethrow)
            {
                Application.Exit();
            }
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionPolicy.HandleException((Exception)e.ExceptionObject, "App Policy");
            // This event always exits the 
            // application so there is no point in looking at 
            // HanleException result.
        }
