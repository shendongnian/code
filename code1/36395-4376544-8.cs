    public class ServiceClientWrapper<ServiceType> : IDisposable
    {
        private ServiceType _channel;
        public ServiceType Channel
        {
            get { return _channel; }
        }
        private static ChannelFactory<ServiceType> _channelFactory;
        public ServiceClientWrapper()
        {
            if(_channelFactory == null)
                 // Given that the endpoint name is the same as FullName of contract.
                _channelFactory = new ChannelFactory<ServiceType>(typeof(T).FullName);
            _channel = _channelFactory.CreateChannel();
            ((IChannel)_channel).Open();
        }
        public void Dispose()
        {
            try
            {
                ((IChannel)_channel).Close();
            }
            catch (Exception e)
            {
                ((IChannel)_channel).Abort();
                // TODO: Insert logging
            }
        }
    }
