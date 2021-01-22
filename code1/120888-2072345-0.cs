    /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main(string[] args)
            {
                if (System.Environment.UserInteractive)
                {
                 
                    if (args.Length > 0)
                    {
                        switch (args[0])
                        {
                            case "-install":
                                {
                                    ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                                    break;
                                }
                            case "-uninstall":
                                {
                                    ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] { new MyService() };
                    ServiceBase.Run(ServicesToRun);
                }
            }
