    using System.ComponentModel;
    using System.Configuration.Install;
    using System.ServiceProcess;
    namespace Example.of.name.space
    {
    [RunInstaller(true)]
    public partial class ServiceInstaller : Installer
    {
        private readonly ServiceProcessInstaller processInstaller;
        private readonly System.ServiceProcess.ServiceInstaller serviceInstaller;
        public ServiceInstaller()
        {
            InitializeComponent();
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // Service will run under system account
            processInstaller.Account = ServiceAccount.LocalSystem;
            // Service will have Start Type of Manual
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = "Windows Automatic Start Service";
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
            serviceInstaller.AfterInstall += ServiceInstaller_AfterInstall;            
        }
        private void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            ServiceController sc = new ServiceController("Windows Automatic Start Service");
            sc.Start();
        }
    }
    }
