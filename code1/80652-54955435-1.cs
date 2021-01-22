    string domainName = "";
    string appPoolName = "";
    string webFiles = "C:\\Users\\John\\Desktop\\New Folder";
    if (IsWebsiteExists(domainName) == false)
    {
        ServerManager iisManager = new ServerManager();
        iisManager.Sites.Add(domainName, "http", "*:8080:", webFiles);
        iisManager.ApplicationDefaults.ApplicationPoolName = appPoolName;
        iisManager.CommitChanges();
    }
    else
    {
        Console.WriteLine("Name Exists already"); 
    }
    public static bool IsWebsiteExists(string strWebsitename)
    {
        ServerManager serverMgr = new ServerManager();
        Boolean flagset = false;
        SiteCollection sitecollection = serverMgr.Sites;
        flagset = sitecollection.Any(x => x.Name == strWebsitename);
        return flagset;
    }
