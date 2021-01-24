    public class SqlRepository
    {
        private readonly GatewaySettings _myConfiguration;
        public SqlRepository(IOptions<GatewaySettings> gatewayOptions)
        {
            _myConfiguration = gatewayOptions.Value;
            // optional null check here
        }
    }
