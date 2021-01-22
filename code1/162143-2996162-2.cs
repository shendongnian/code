    public class ServerConfigurationSection : ConfigurationSection
    {
      [ConfigurationProperty("servers")]
      public ServerConfigurationElementCollection Servers {
        get { return (ServerConfigurationElementCollection)this["servers"]; }
        set { this["servers"] = value; }
      }
      
      public static ServerConfigurationSection GetConfiguration() {
        return ConfigurationManager.GetSection("ServerInfo") as ServerConfigurationSection;
      }
    }
