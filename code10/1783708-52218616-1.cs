    public class SomeClass
    {
       private readonly SystemConfiguration _systemConfiguration{get;set;}
       public SomeClass (IOptions<ConfigExternalService> systemConfiguration)
       {
        _systemConfiguration = systemConfiguration;
       }
    }
