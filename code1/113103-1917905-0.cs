    foreach (MYINTERFACE mod in this.Modules) 
    {
        ServiceHost serviceHost = new ServiceHost(
            mod, new Uri[] { new Uri("BINDING URL") });
        var binding = new NetTcpBinding();
        binding.Security.Mode = SecurityMode.None;
        var serviceEndpoint = serviceHost.AddServiceEndpoint(
            typeof(ENDPOINT TYPE), binding, "");
        serviceHost.Open();
        this.ServiceHosts = new List<ServiceHost>();
        this.ServiceHosts.Add(serviceHost);
    }
