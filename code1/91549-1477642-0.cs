    [RunInstaller(true)]
    public class ProjectInstaller : System.Configuration.Install.Installer 
    {
        public ProjectInstaller()
        {
            ...
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
        }
    }
