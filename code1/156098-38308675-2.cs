        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                MyService s1 = new MyService();
                if (args.Length == 1)
                {
                    switch (args[0])
                    {
                        case "-install":
                            s1.InstallService();
                            
                            break;
                        case "-uninstall":
                            
                            s1.UninstallService();
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
            else {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new MyService() 
                };
                ServiceBase.Run(MyService);            
            }
        }
