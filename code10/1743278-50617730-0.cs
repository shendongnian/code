    if (Application.Current != null)
                {
                    Application.Current.DispatcherUnhandledException += (s, a) =>
                    {
                        Reporter.AddLog(a.Exception);
    
                        DisplayAppropriateNotification(a);
    
                        a.Handled = true;
                    };
                }
