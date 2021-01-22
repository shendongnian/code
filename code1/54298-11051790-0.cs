    public string GetMeMyInfo(string searchCriteria)
    {
    //Instatiate the web service and declare the necessary variables
    WsService.WsServiceBus oWsGetInfo = new WsService.WsServiceBus();
    //Configure the Web Service Proxy
    oWsGetInfo.Proxy = System.Net.WebProxy.GetDefaultProxy();
    oWsGetInfo.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    //Invoke the web service
    return oWsGetInfo.GetInfo4Me(searchCriteria);
    }
