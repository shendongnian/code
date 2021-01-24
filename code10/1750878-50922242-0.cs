    private static bool resetConnection;
    private static string authKey;
    private static string proxyUrl;
    public static string AuthKey
    {
        get => authKey;
        set
        {
           authKey = value;
           resetConnection = true;
        }
    }
    public static string ProxyUrl
    {
        get => proxyUrl;
        set
        {
           proxyUrl = value;
           resetConnection = true;
        }
    }
    public static MyConnection HelperInstance
    {
        get
        {
            if(resetConnection == null)
            {
                instance = new MyConnection(proxyUrl, authKey);
                resetConnection = false;
            }
            if(instance == null)
            {
                instance = new MyConnection(proxyUrl, authKey);
                resetConnection = false;
            }
            return instance;
        }
    }
