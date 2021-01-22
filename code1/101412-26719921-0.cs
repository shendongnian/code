    private string WebsiteName()
    {
        string websiteName = string.Empty;
        string AppPath = string.Empty;
        AppPath = Context.Request.ServerVariables["INSTANCE_META_PATH"];
        AppPath = AppPath.Replace("/LM/", "IIS://localhost/");
        DirectoryEntry root = new DirectoryEntry(AppPath);
        websiteName = (string)root.Properties["ServerComment"].Value;
        return websiteName;
    }
