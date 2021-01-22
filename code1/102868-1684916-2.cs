    public class ServiceConfigurationHandler : IConfigurationSectionHandler
    {
       public ServiceConfigurationHandler() { }
        
       public object Create(object parent, object configContext, XmlNode section)
       {
           return new ServiceConfiguration((XmlElement)section);
       }
    }
