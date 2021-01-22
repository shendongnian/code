    public static void RemoveMexEndpointDispatcher(this ServiceHost host)
    {
        // In the simple example, we only define one MEX endpoint for
        // one transport protocol
        var queryMexChannelDisps = 
                host.ChannelDispatchers.Where(
                    disp => (((ChannelDispatcher)disp).Endpoints[0].ContractName
                                                == "IMetadataExchange"));
        var channelDisp = (ChannelDispatcher)queryMexChannelDisps.First();
    
        // Save the MEX EndpointDispatcher
        ((IWCFState)host).MexEndpointDispatcher = channelDisp.Endpoints[0];
     
        channelDisp.Endpoints.Remove(channelDisp.Endpoints[0]);
    }
