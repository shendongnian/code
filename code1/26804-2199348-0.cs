    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
	{
		var serviceHost = base.CreateServiceHost(serviceType, baseAddresses);
		var webHttpBinding = new WebHttpBinding();
		var serviceEndpoint1 = serviceHost.AddServiceEndpoint(typeof(IService), webHttpBinding,
															 "http://company2.product.com/WCFService/Service.svc");
		
		var serviceEndpoint2 = serviceHost.AddServiceEndpoint(typeof(IService), webHttpBinding,
													 "http://company1.product.com/WCFService/Service.svc");
		var webHttpBehavior = new WebHttpBehavior();
		serviceEndpoint1.Behaviors.Add(webHttpBehavior);
		serviceEndpoint2.Behaviors.Add(webHttpBehavior);
		
		return serviceHost;
	}
