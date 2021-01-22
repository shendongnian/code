    static string ConnectionString
    {
    #if DEBUG
        get { return "<debug connection string>"; }
    #else
        get { return "<release connection string>"; }
    #endif
    }
