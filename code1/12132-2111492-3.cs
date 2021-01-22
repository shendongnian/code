    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        protected virtual string AppendPathParameter(string path, string parameter)
        {
            if (path.Length > 0 && path[0] != '"')
            {
                path = "\"" + path + "\"";
            }
            path += " " + parameter;
            return path;
        }
        protected override void OnBeforeInstall(System.Collections.IDictionary savedState)
        {
            Context.Parameters["assemblypath"] = AppendPathParameter(Context.Parameters["assemblypath"], "/service");
            base.OnBeforeInstall(savedState);
        }
        protected override void OnBeforeUninstall(System.Collections.IDictionary savedState)
        {
            Context.Parameters["assemblypath"] = AppendPathParameter(Context.Parameters["assemblypath"], "/service");
            base.OnBeforeUninstall(savedState);
        }
    }
