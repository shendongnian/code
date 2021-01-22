    public TContract GetService<TContract>(EndpointAddress address){
        var channelFactory = new ChannelFactory<TContract>(new NetTcpBinding(),address);
        return channelFactory.CreateChannel();
    }
                    
