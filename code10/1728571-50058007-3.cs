    public WCFClient<T> GetMicroService<T>(string serviceName, T contract)
        where T : IWCFServiceBase
    {
        Dictionary<IWCFServiceBase, WCFClient<IWCFServiceBase>> service;
        WCFClient<IWCFServiceBase> client;
        if (Services.TryGetValue(serviceName, out service) &&
            service.TryGetValue(contract, out client))
        {
            // client will just be WCFClient<IWCFServiceBase>, so we need to cast
            return (WCFClient<T>) (object) client;
        }
        // Throw an exception or whatever...
    }
