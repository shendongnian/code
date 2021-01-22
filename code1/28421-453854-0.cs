    IDictionary<string, ServiceHost> hosts;
    NetTcpBinding binding;
    CustomBinding mexBinding;
    private void AddService(Type serviceImp, Type serviceDef, string serviceName)
        {
            ServiceHost host = new ServiceHost(serviceImp);
            string address = String.Format(baseAddress, wcfPort, serviceName); 
            
            string endAdd = address;
            string mexAdd = address + "/mex";
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            host.Description.Behaviors.Add(behavior);
            host.AddServiceEndpoint(serviceDef, binding, endAdd);
            host.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, mexAdd);
            host.Open();
            hosts.Add(serviceDef.Name, host);
        }
