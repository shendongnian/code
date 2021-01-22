    Func<object> createChannel = () =>
        ChannelFactory<IHelloWorldService>
            .CreateChannel(new NetTcpBinding(), new EndpointAddress(uri));
    var factory = new WcfProxyFactory();
    var proxy = factory.Create<IDisposableHelloWorldService>(createChannel);
    proxy.HelloWorld();
