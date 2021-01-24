        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationManager.ConnectionStrings = Configuration.GetSection("ConnectionStrings").Get<Dictionary<string, string>>();
        }
