    // usings:
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Configuration;
    using System.Configuration;
    
    void ConsumeWebService()
    {
        var myBinding = new CustomBinding("xxxxxAPIPortBinding");
    
        // Manually define Endpoint:
        //var myEndpoint = new EndpointAddress("http://localhost/myservice");
    
        // Or get from configuration file:
        ClientSection clientSection = (ClientSection)ConfigurationManager.GetSection("system.serviceModel/client");
        ChannelEndpointElement myEndpoint = clientSection.Endpoints[0];
    
        // Define a communication channel, based on the interface, bindig e endpoint
        var myChannelFactory = new ChannelFactory<xxxxxAPI.PlunetAPI>(myBinding, myEndpoint.Address.AbsoluteUri);
        xxxxxAPI.PlunetAPIclient client = null;
    
        try
        {
            // Create the channel to consume the service
            client = myChannelFactory.CreateChannel();
            client.MyMethod();  //Calls some method
            ((ICommunicationObject)client).Close();
        }
        catch
        {
            if (client != null)
            {
                ((ICommunicationObject)client).Abort();
            }
        }
    }
