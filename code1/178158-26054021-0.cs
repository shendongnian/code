    public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
            container
                .AddFacility<WcfFacility>(f =>
                {
                    f.CloseTimeout = TimeSpan.Zero;
                });
            
            string baseAddress = "http://localhost:8744/TVIRecorderWcfService/";
            container.Register(
                Component
                    .For<ITVIRecorderWcfService>()
                    .ImplementedBy<TVIRecorderWcfService>()
                    .AsWcfService(
                    new DefaultServiceModel()
                        .AddBaseAddresses(baseAddress)
                        .Hosted()
                        //publish metadata doesn't work, have to do differently
                        //.PublishMetadata(x => x.EnableHttpGet()).Discoverable()
                        .AddEndpoints(WcfEndpoint
                            .BoundTo(new BasicHttpBinding()))
                            //.PublishMetadata(x=>x.EnableHttpGet()).Discoverable()
                            ).LifestyleSingleton()
                            ,
                Component
                    .For<ServiceBase>()
                    .ImplementedBy<TVIRecorderService>());
        }
