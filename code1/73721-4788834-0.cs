    RemotingConfiguration.Configure(appConfig, false);
    // do this to unregister the channel
    IChannel[] regChannels = ChannelServices.RegisteredChannels;
    IChannel channel = (IChannel)ChannelServices.GetChannel(regChannels[0].ChannelName);
    ChannelServices.UnregisterChannel(channel);
    RemotingConfiguration.Configure(appConfig, false); // this is just a test to see if we get an error
