    public class ServerConfigurationElement : ConfigurationElement
    {
      [ConfigurationProperty("id")]
      public int Id {
        get { return (int)this["id"]; }
        set { this["id"] = value; }
      }
      [ConfigurationProperty("name")]
      public string Name { 
        get { return (string)this["name"]; }
        set { this["name"] = value; }
      }
      
      [ConfigurationProperty("key")]
      public int Key {
        get { return (int)this["key"]; }
        set { this["key"] = value;
      }
      
      [ConfigurationProperty("ip")]
      public string IPAddress {
        get { return (string)this["ip"]; }
        set { this["ip"] = value; }
      }
      
      [ConfigurationProperty("port")]
      public int Port {
        get { return (int)this["port"]; }
        set { this["port"] = value; }
      }
    }
