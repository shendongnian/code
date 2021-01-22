    var myBinding = new BasicHttpBinding();
    var myEndpoint = new EndpointAddress("http://localhost/myservice");
    var myChannelFactory = new ChannelFactory<IMyService>(myBinding, myEndpoint);
    
    IMyService client = null;
    
    try
    {
        client = myChannelFactory.CreateChannel();
        client.MyServiceOperation();
        ((ICommunicationObject)client).Close();
    }
    catch
    {
        if (client != null)
        {
            ((ICommunicationObject)client).Abort();
        }
    }
