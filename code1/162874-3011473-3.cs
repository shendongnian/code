    public MyServiceFactory : IMyServiceFactory
    {
        public IMServiceChannel CreateChannel()
        {
            return new ChannelFactory<IMyServiceChannel>().CreateChannel();
        }
    }
