    [RunInstaller(true)]
    public class MyInstaller: Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
    
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }
    
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }
    
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
    }
