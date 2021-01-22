    [RunInstaller(true)]
    public class MyInstaller : Installer
    {
        public HelloInstaller()
            : base()
        {
        }
    
        public override void Commit(IDictionary mySavedState)
        {
            base.Commit(mySavedState);
            System.IO.File.CreateText("Commit.txt");
        }
    
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            System.IO.File.CreateText("Install.txt");
        }
    
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            File.Delete("Commit.txt");
            File.Delete("Install.txt");
        }
    
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            File.Delete("Install.txt");
        }
    }
