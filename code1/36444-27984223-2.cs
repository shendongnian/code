    public class ServiceHelper
    {
        private readonly ChannelFactory<IMyService> _channelFactory;
        public ServiceHelper(ChannelFactory<IMyService> channelFactory )
        {
            _channelFactory = channelFactory;
        }
        public IMyService CreateChannel()
        {
            var channel = _channelFactory.CreateChannel();
            var channelDisposer = new ProxyDisposer(channel as IClientChannel);
            return new ProxyWrapper(channel, channelDisposer);
        }
    }
