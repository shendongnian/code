        try
        {
            AppDomain.CurrentDomain.UnhandledException +=
                (object sender, UnhandledExceptionEventArgs e) =>
                {
                    CrashOn((Exception)e.ExceptionObject, e.IsTerminating);
                };
            var mainWindow = new MainWindow();
            MobileDevice.Hibernate += (sender, e) => { mainWindow.Hibernate(); };
            Application.Run(mainWindow);
        }
        catch (Exception huh)
        {
            CrashOn(huh, false);
        }
