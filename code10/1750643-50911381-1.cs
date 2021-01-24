    services.Configure<GatewaySettings>(Configuration.GetSection("GatewaySettings"));
      public class SqlRepository
      {
        private readonly GatewaySettings _myConfiguration;
        public SqlRepository(IOptions<GatewaySettings> settingsAccessor)
        {
              _myConfiguration = settingsAccessor.Value;
        }
      }
