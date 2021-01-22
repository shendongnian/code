    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;
        public ProjectInstaller()
        {
            InitializeComponent();
            // adjust configuration to whatever is needed
            serviceInstaller = new ServiceInstaller();
            serviceInstaller.ServiceName = "My Service";
            serviceInstaller.DisplayName = "My Service";
            serviceInstaller.StartType = ServiceStartMode.Manual;
            this.Installers.Add(serviceInstaller);
            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceProcessInstaller.Account = 
                System.ServiceProcess.ServiceAccount.LocalSystem;
            serviceProcessInstaller.Password = null;
            serviceProcessInstaller.Username = null;
            this.Installers.Add(serviceProcessInstaller);
        }
        protected override void OnCommitted(IDictionary savedState)
        {
            base.OnCommitted(savedState);
            // The following code sets the flag to allow desktop interaction 
            // for the service
            //
            using (RegistryKey ckey = 
                Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Services\My Service", true))
            {
                if (ckey != null && ckey.GetValue("Type") != null)
                {
                    ckey.SetValue("Type", (((int)ckey.GetValue("Type")) | 256));
                }
            }
        }
    }
