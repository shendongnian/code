    [ConfigurationCollection(typeof(ServerConfigurationElement), AddItemName = "server")]
    public class ServerConfigurationElementCollection : ConfigurationElementCollection
    {
      protected override CreateNewElement() {
        return new ServerConfigurationElement();
      }
      
      protected override object GetElementKey(ConfigurationElement element) {
        return ((ServerConfigurationElement)element).Id;
      }
    }
