    var baseAddress = new Uri("http://localhost:15003/MockGateway");
    using (var host = new ServiceHost(new MockGatewayService(), baseAddress))
    {
        // Since we are passing an instance of the service into ServiceHost (rather 
        // than passing in the type) we have to set the context mode to single.
        var behavior = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
        behavior.InstanceContextMode = InstanceContextMode.Single;
        // Continue to use the service here.  If you ever need to get a reference
        // to the service object you can do so with...
        MockGatewayService myService = host.SingletonInstance as MockGatewayService;
        
        // ...
    }
              
