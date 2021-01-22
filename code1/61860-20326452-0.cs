    MyServiceClient client = new MyServiceClient(binding, endpoint);
    client.Endpoint.Address = new EndpointAddress("net.tcp://localhost/webSrvHost/service.svc");
    client.Endpoint.Binding = new NetTcpBinding()
                {
                    Name = "yourTcpBindConfig",
                    ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                    ListenBacklog = 40 }
