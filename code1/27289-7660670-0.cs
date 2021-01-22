    public static class MockServiceHostFactory
    {
        public static ServiceHost GenerateMockServiceHost<TMock>(TMock mock, Uri baseAddress, string endpointAddress)
        {
            var serviceHost = new ServiceHost(mock, new[] { baseAddress });
     
            serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
            serviceHost.Description.Behaviors.Find<ServiceBehaviorAttribute>().InstanceContextMode = InstanceContextMode.Single;
     
            serviceHost.AddServiceEndpoint(typeof(TMock), new BasicHttpBinding(), endpointAddress);
     
            return serviceHost;
        }
    }
