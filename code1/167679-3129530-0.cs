    class Program
    {
        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
            {
                SvcInstaller inst = new SvcInstaller();
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    // Service.OnStart() creates instance of MainLib() 
                    // and then calls its MainLib.Start() method
                    new Service()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                MainLib lib = new MainLib();
                lib.Start();
                // ...
            }
        }
    }
