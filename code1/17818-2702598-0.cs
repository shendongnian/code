    [TestClass] public class InstallerTest {
    [TestMethod]
    public void InstallTest() {
      DataWarehouseInstall installer = new DataWarehouseInstall();
      string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      string installLogFilePath = Path.Combine(assemblyDirectory, "install.log");
      installer.Context = new System.Configuration.Install.InstallContext(installLogFilePath, null);      
      // set any parameters
      installer.Context.Parameters.Add("Server", ".");
      //installer.Context.Parameters.Add("User", "");
      //installer.Context.Parameters.Add("Password", "");
      installer.Context.Parameters.Add("DatabaseName", "MyDatabaseInstallMsiTest");
      //installer.Context.Parameters.Add("DatabasePath", "");
      
      // Our test isn't injecting any save state so we give a default instance for the stateSaver
      installer.Install(new Hashtable());
    } }
