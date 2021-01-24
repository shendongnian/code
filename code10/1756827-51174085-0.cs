    private MyServiceClient = _service;
    public MyClass(string serviceUri)
    {
        if (string.IsNullOrEmpty(serviceUri))
        {
            _service = new MyServiceClient();
        }
        else
        {
            var binding = new System.ServiceModel.BasicHttpBinding() { MaxReceivedMessageSize = int.MaxValue };
            var endpoint = new System.ServiceModel.EndpointAddress(serviceUri);
            _service = new MyServiceClient (binding, endpoint);
        }
    }
