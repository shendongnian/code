    public class ValuesController
    {
        public ValuesController()
            : this(new OptionsWrapper<Config>(new Config() { ConnectionString = "default ConnectionString" }))
        {
        }
        public ValuesController(IOptions<Config> configSettings)
        {
        }
    }
    public class Config
    {
        public string ConnectionString { get; set; }
    }
