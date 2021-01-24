    public WCFClient<T> GetMicroService<T>(string serviceName, T contract)
        where T : IWCFServiceBase
    {
        if (Services.TryGetValue(serviceName, out var service) &&
            service.TryGetValue(contract, out var client))
        {
            // client will just be WCFClient<IWCFServiceBase>, so we need to cast
            return (WCFClient<T>) client;
        }
        // Throw an exception or whatever...
    }
