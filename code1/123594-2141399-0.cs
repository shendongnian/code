    /// <summary>
    /// The installer class for the application
    /// </summary>
    [RunInstaller(true)]
    public class MyInstaller : Installer
    {
        /// <summary>
        /// Constructor for the installer
        /// </summary>
        public MyInstaller()
        {
            // Create the Service Installer
            ServiceInstaller myInstaller = new ServiceInstaller();
            myInstaller.DisplayName = "My Service";
            myInstaller.ServiceName = "mysvc";
            // Add the installer to the Installers property
            Installers.Add(myInstaller);
        }
    }
