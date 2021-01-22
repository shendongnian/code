    public class MySettings : ConfigurationSection 
    {
        public MySettings Settings = (MySettings)WebConfigurationManager.GetSection("MySettings");
        [ConfigurationProperty("MyConfigSetting1")]
        public string DefaultConnectionStringName
        {
            get { return (string)base["MyConfigSetting1"]; }
            set { base["MyConfigSetting1"] = value; }
        }
    }
