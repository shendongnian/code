    [RunInstaller(true)]
    public partial class Service1Installer : Installer
    {
        public Service1Installer()
        {
            InitializeComponent();
            ServiceProcessInstaller process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            ServiceInstaller serviceAdmin = new ServiceInstaller();
            serviceAdmin.StartType = ServiceStartMode.Manual;
            serviceAdmin.ServiceName = "Service1";
            serviceAdmin.DisplayName = "Service1";
            serviceAdmin.Description = "Service1";
            Installers.Add(serviceAdmin);
        }
    }
