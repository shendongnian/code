    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        protected override void OnBeforeInstall(System.Collections.IDictionary savedState)
        {
            Context.Parameters["assemblypath"] += "\" /service";
            base.OnBeforeInstall(savedState);
        }
        protected override void OnBeforeUninstall(System.Collections.IDictionary savedState)
        {
            Context.Parameters["assemblypath"] += "\" /service";
            base.OnBeforeUninstall(savedState);
        }
    }
