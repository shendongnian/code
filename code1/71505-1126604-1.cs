    string ResourceName { get { return "AppName"; } }
    public static string AppName
    {
        return GetString(ResourceName);
    }
