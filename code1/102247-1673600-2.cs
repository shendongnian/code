    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel;
    using System.ServiceProcess;
    
    namespace WindowsServiceTest
    {
        [RunInstaller(true)]
        public class MyServiceInstaller : System.Configuration.Install.Installer
        {
            public MyServiceInstaller()
            {
                ServiceProcessInstaller process = new ServiceProcessInstaller();
    
                process.Account = ServiceAccount.LocalSystem;
    
                ServiceInstaller serviceAdmin = new ServiceInstaller();
    
                serviceAdmin.StartType = ServiceStartMode.Manual;
                serviceAdmin.ServiceName = "Service1";
                serviceAdmin.DisplayName = "Service1 Display Name";
                Installers.Add(process);
                Installers.Add(serviceAdmin);
            }
        }
    }
