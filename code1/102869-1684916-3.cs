    public class ServiceConfiguration
    {
       public static readonly ServiceConfiguration Current = (ServiceConfiguration)ConfigurationManager.GetSection("me/services");
    
       private List<ISubService> m_services;
       private string m_serviceName;
    
       internal ServiceConfiguration(XmlElement xmlSection)
       {
           // loop through the config and initialize the services
           // service = createinstance(type)..kind of deal
           // m_services.Add( service );
       }
    
       public void Start( )
       {
           foreach( ISubService service in m_services ) { service.Start( ); }           
       }
       public void Stop( ) { ... }
    }
