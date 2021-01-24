    public class SomeChannelFactory : ChannelFactory
    {
        public SomeChannelFactory()
        {
            InitializeEndpoint( new BasicHttpBinding() , new EndpointAddress( "http://localhost/service" ) );
        }
    
        protected override ServiceEndpoint CreateDescription()
        {
            return new ServiceEndpoint( new ContractDescription( nameof( SomeChannelFactory ) ) );
        }
    }
