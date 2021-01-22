    [RunInstaller(true)]
    public class WindowsServiceInstaller : Installer
    {
        public WindowsServiceInstaller()
        {
            ServiceInstaller si = new ServiceInstaller();
            si.StartType = ServiceStartMode.Automatic; // get this value from some global variable
            si.ServiceName = @"YOUR APP";
            si.DisplayName = @"YOUR APP";
            this.Installers.Add(si);
    
            ServiceProcessInstaller spi = new ServiceProcessInstaller();
            spi.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            spi.Username = null;
            spi.Password = null;
            this.Installers.Add(spi);
        }
    }
