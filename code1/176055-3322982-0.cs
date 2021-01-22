    public static void CreateNewWebSite(string siteID, string hostname)
    {
        DirectoryEntry webService = new DirectoryEntry("IIS://LOCALHOST/W3SVC");
        DirectoryEntry website = new DirectoryEntry();
        website = webService.Children.Add(siteID, "IIsWebServer");
        website.CommitChanges();
        website.Invoke("Put", "ServerBindings", ":80:" + hostname);
        // Or website.Properties["ServerBindings"].Value = ":80:" + hostname;            
        website.Properties["ServerState"].Value = 2;
        website.Properties["ServerComment"].Value = hostname;
        website.CommitChanges();
        DirectoryEntry rootDir = website.Children.Add("ROOT", "IIsWebVirtualDir");
        rootDir.CommitChanges();
        rootDir.Properties["AppIsolated"].Value = 2;
        rootDir.Properties["Path"].Value = @"C:\Inetpub\wwwroot\MyRootDir";
        rootDir.Properties["AuthFlags"].Value = 5;
        rootDir.Properties["AccessFlags"].Value = 513;
        rootDir.CommitChanges();
        website.CommitChanges();
        webService.CommitChanges();
    }
