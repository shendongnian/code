    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
      public ProjectInstaller()
      {
        this.InitializeComponent();
      }
      private void InitializeComponent()
      {
        this.AfterInstall += new InstallEventHandler(ProjectInstaller_AfterInstall);
      }
      void ProjectInstaller_AfterInstall(object sender, InstallEventArgs e)
      {
        string path = this.Context.Parameters["DIR"] + "YourFileName.config";
        // make sure you replace your filename with the filename you actually
        // want to read
        // Then You can read your config using XML to Linq Or you can use
        // WebConfigurationManager whilst omitting the .config from the path
      }
