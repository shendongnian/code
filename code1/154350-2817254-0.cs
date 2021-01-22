    Uri baseAddress = new Uri("http://localhost:8000/ServiceModel");
    ServiceHost selfHost = new ServiceHost(typeof(TestService), baseAdress);
    
    selfHost.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), "Service");
    selfHost.AddServiceEndpoint(typeof(IService2), new WSHttpBinding(), "Service1");
    
    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
    smb.HttpGetEnabled = true;
    selfHost.Description.Behaviors.Add(smb);
