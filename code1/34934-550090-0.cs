    VirtualDirectoryMapping vdm = new VirtualDirectoryMapping(@"C:\Inetpub\wwwroot\YourApplication", true);
    WebConfigurationFileMap wcfm = new WebConfigurationFileMap();
    wcfm.VirtualDirectories.Add("/", vdm);
    // Get the connectionString
    Configuration config = WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
    string connection = config.ConnectionStrings.ConnectionStrings["YourConnectionString"];
