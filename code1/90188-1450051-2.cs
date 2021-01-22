    using System;
    using System.Collections.Generic;
    using System.Configuration.Install; 
    using System.IO;
    using System.Linq;
    using System.Reflection; 
    using System.ServiceProcess;
    using System.Text;
    static void Main(string[] args)
    {
        if (System.Environment.UserInteractive)
        {
            string parameter = string.Concat(args);
            switch (parameter)
            {
                case "--install":
                    ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                    break;
                case "--uninstall":
                    ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                    break;
            }
        }
        else
        {
            ServiceBase.Run(new WindowsService());
        }
    }
