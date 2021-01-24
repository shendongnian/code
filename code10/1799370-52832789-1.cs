    private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {   
            new MessageBoxService().Show(e.Exception.StackTrace, e.Exception.Message);
            if (System.Diagnostics.Debugger.IsAttached)
            {
                System.Diagnostics.Debugger.Break();
            }
 
            e.Handled = true; 
        }
