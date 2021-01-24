    void ConfigureEndPoint<T>(Host host, Config cfg, Provider provider, string endPointName)
    {
        cfg.ReceiveEndpoint(host, endPointName, e =>
        {
            e.LoadFrom(provider);
            EndpointConvention.Map<T>(e.InputAddress);
        }
    }
