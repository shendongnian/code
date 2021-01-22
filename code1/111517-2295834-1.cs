    [System.ComponentModel.ToolboxItem(false)]
        [RunInstaller(true)]
    public class InstallerClass : ManifestInstaller
    {
        public InstallerClass()
            : base()
        { }
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
        }
        public override void Rollback(System.Collections.IDictionary savedState)
        {
            base.Rollback(savedState);
        }
    }
