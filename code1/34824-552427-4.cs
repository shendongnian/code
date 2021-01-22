    public static void AddMexEndpointDispatcher(this ServiceHost host)
    {
        var queryMexChannelDisps =
                host.ChannelDispatchers.Where(
                        disp => (((ChannelDispatcher)disp).Endpoints.Count == 0));
        var channelDisp = (ChannelDispatcher)queryMexChannelDisps.First();
    
        // Add the MEX EndpointDispatcher
        channelDisp.Endpoints.Add(((IWCFState)host).MexEndpointDispatcher);
    }
