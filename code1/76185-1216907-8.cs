    public static AWSECommerceServicePortTypeClient NewSignedClient()
    {
        var service = new AWSECommerceServicePortTypeClient(new BasicHttpBinding(BasicHttpSecurityMode.Transport), new EndpointAddress(Helpers.AWSUrl));
        service.ChannelFactory.Endpoint.Behaviors.Add(new SigningBehavior());
        return service;
    }
