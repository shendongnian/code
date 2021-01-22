    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container
            .AddFacility<WcfFacility>()
            .Register(
                Component.For<ICoreService>()
                .ImplementedBy<CoreService>()
                .AsWcfService(new DefaultServiceModel()
                    .AddBaseAddresses("http://localhost:1000/core")
                    .AddEndpoints(WcfEndpoint.BoundTo(new BasicHttpBinding()))
                        .PublishMetadata(o => o.EnableHttpGet()))
        );
    }
