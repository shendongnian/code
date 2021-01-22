                IMyServiceContract myServiceObject = new MyService(); /* container.Resolve<IMyServiceContract>(); */
                HostFactory.Run(x =>
                {
                    x.Service<IMyServiceContract>(s =>
                    {
                        s.ConstructUsing(name => myServiceObject);
                        s.WhenStarted(sw => sw.Start());
                        s.WhenStopped(sw => sw.Stop());
                        s.WhenSessionChanged((csm, hc, chg) => csm.SessionChanged(chg)); /* THIS IS MAGIC LINE */
                    });
                    x.EnableSessionChanged(); /* THIS IS MAGIC LINE */
					
                    /* use command line variables for the below commented out properties */
                    /*
                    x.RunAsLocalService();
                    x.SetDescription("My Description");
                    x.SetDisplayName("My Display Name");
                    x.SetServiceName("My Service Name");
                    x.SetInstanceName("My Instance");
                    */
                    x.StartManually(); // Start the service manually.  This allows the identity to be tweaked before the service actually starts
                    /* the below map to the "Recover" tab on the properties of the Windows Service in Control Panel */
                    x.EnableServiceRecovery(r =>
                    {
                        r.OnCrashOnly();
                        r.RestartService(1); ////first
                        r.RestartService(1); ////second
                        r.RestartService(1); ////subsequents
                        r.SetResetPeriod(0);
                    });
                    x.DependsOnEventLog(); // Windows Event Log
                    x.UseLog4Net();
                    x.EnableShutdown();
                    x.OnException(ex =>
                    {
                        /* Log the exception */
                        /* not seen, I have a log4net logger here */
                    });
                });					
