    public class MyProjectBootstrapper : UnityBootstrapper
    {
    
      protected override void ConfigureContainer()
      {
        // ... stuff
    
        // create constructor injection for the MyCustomLoggerAdapterExtendedAdapter
          var logPolicyConfigSection = ConfigurationManager.GetSection( LogPolicies.CorporateLoggingConfiguration );
          var injectedLogPolicy = new InjectionConstructor( logPolicyConfigSection as LoggingPolicySection );
    
          // register the MyCustomLoggerAdapterExtendedAdapter
          Container.RegisterType<IFormalLogger, MyCustomLoggerAdapterExtendedAdapter>(
                  new ContainerControlledLifetimeManager(), injectedLogPolicy );
    
      }
      
        private readonly MyCustomLoggerAdapter _logger = new MyCustomLoggerAdapter();
        protected override ILoggerFacade LoggerFacade
        {
            get
            {
                return _logger;
            }
        }
    
    }
