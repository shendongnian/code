    Castle.DynamicProxy.Generators.AttributesToAvoidReplicating.Add<ServiceContractAttribute>();
     
    var myWcfServiceMock = Substitute.For<IMyWcfService>();
    var mockServiceHost = MockServiceHostFactory.GenerateMockServiceHost(myWcfServiceMock , new Uri("http://localhost:8001"), "MyService");
    mockServiceHost.Open();
    ...
    mockServiceHost.Close();
