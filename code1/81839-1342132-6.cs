    internal class PolicyServerSinkProvider : IServerChannelSinkProvider
    {
      public void GetChannelData(IChannelDataStore channelData){}
    
      public IServerChannelSink CreateSink(IChannelReceiver channel)
      {
        IServerChannelSink nextSink = null;
        if (Next != null)
          nextSink = Next.CreateSink(channel);
        return new PolicyServerSink(channel, nextSink);
      }
    
      public IServerChannelSinkProvider Next { get; set; }
    }
