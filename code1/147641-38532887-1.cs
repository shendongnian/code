    //Define the builder
    var builder = new ContainerBuilder();
    //Instantiate your Proxy options with a selector
    var proxyOptions = new ProxyGenerationOptions {Selector = new MyInterceptSelector()};
    //Pass the proxy options as a parameter to the EnableInterfaceInterceptors method
    builder.RegisterType<MyRepo>()
                .As<IMyRepo>()
                .EnableInterfaceInterceptors(proxyOptions)
                .InterceptedBy(typeof(IInterceptor));
