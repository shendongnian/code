    services.Configure<SystemConfiguration>(options => Configuration.GetSection("SystemConfiguration").Bind(options));
    
    public class SystemConfiguration
    {
       public string EncryptionKey{get;set;}
    }
