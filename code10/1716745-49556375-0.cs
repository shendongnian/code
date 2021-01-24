    public class ConfigSettings : IConfig
    {
        public string Connstring { get; }
        public string Context { get; set; }
        public ConfigSettings()
        {
            this.Context = ConfigurationManager.AppSettings["Context"];
            this.Connstring = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["Context"]]
                .ConnectionString;
        }
    }
