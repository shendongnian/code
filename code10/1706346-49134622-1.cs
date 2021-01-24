    var binding = new BasicHttpsBinding();
    var endpoint = new EndpointAddress(new Uri("https://myservice.com"));
    var channelFactory = new ChannelFactory<MyService>(binding, endpoint);
    // Must set before CreateChannel()
    channelFactory.Credentials.
        ClientCertificate.Certificate = token.Certificate;
    var serviceClient = channelFactory.CreateChannel();
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
