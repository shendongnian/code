    public ProjectDB(bool useWebServiceConnection) 
        : base(ConfigurationManager.AppSettings[useWebServiceConnection ? "ServiceConnectionString" : "SomeOtherConnectionString"])
    {
        this.useWebServiceConnection = useWebServiceConnection;
    }
