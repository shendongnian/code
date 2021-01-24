    using Topshelf;
    using Topshelf.HostConfigurators;
    using Topshelf.Logging;
    using Topshelf.ServiceConfigurators;
    
    namespace LogIssue
    {
        public class Program
        {
            public const string Name = "LogIssue";
    
            public static void Main(string[] args)
            {
                HostFactory.Run(ConfigureHost);
            }
    
            private static void ConfigureHost(HostConfigurator x)
            {
                x.Service<WindowsService>(ConfigureService);
    
                x.SetServiceName(Name);
                x.SetDisplayName(Name);
                x.SetDescription(Name);
    
                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.OnException(ex => HostLogger.Get(Name).Error(ex));
            }
    
            private static void ConfigureSystemRecovery(ServiceRecoveryConfigurator serviceRecoveryConfigurator) =>
                serviceRecoveryConfigurator.RestartService(delayInMinutes: 1);
    
            private static void ConfigureService(ServiceConfigurator<WindowsService> serviceConfigurator)
            {
                serviceConfigurator.ConstructUsing(() => new WindowsService());
                serviceConfigurator.WhenStarted(service => service.OnStart());
                serviceConfigurator.WhenStopped(service => service.OnStop());
            }
        }
    }
