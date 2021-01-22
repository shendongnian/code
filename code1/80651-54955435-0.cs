    public static bool IsWebsiteExists(string strWebsitename)
    {
        ServerManager serverMgr = new ServerManager();
        Boolean flagset = false;
        SiteCollection sitecollection = serverMgr.Sites;
        flagset = sitecollection.Any(x => x.Name == strWebsitename);
        return flagset;
    }
