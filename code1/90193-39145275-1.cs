    config.MessageHandlers.Add(new ThrottlingHandler()
    {
        Policy = new ThrottlePolicy(perSecond: 1, perMinute: 30, perHour: 500, perDay:2000)
        {
            IpThrottling = true,
            ClientThrottling = true,
            EndpointThrottling = true
        },
        Repository = new CacheRepository()
    });
