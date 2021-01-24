    #if DEBUG
        Channel channel = new Channel(emulatorAddr, ChannelCredentials.Insecure);
        PublisherServiceApiClient pub = PublisherServiceApiClient.Create(channel);
    #else
        PublisherServiceApiClient pub = PublisherServiceApiClient.Create();
    #endif
