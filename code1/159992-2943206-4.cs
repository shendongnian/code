    var myBinding = new BasicHttpBinding();
    var myEndpoint = new EndpointAddress("http://localhost/myservice");
    using (var myChannelFactory = new ChannelFactory<IMyService>(myBinding, myEndpoint))
    {
        IMyService client = null;
    
        try
        {
            client = myChannelFactory.CreateChannel();
            client.MyServiceOperation();
            ((ICommunicationObject)client).Close();
            myChannelFactory.Close();
        }
        catch
        {
            ((ICommunicationObject)client)?.Abort();
        }
    }
