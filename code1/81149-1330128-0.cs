    public class Global : HttpApplication {
        
        static Global() {
            DomainService.Factory = new MyAppDomainServiceFactory();
        }
    }
        
    internal sealed class MyAppDomainServiceFactory : IDomainServiceFactory {
        
        public DomainService CreateDomainService(Type domainServiceType,
                                                 DomainServiceContext context) {
            DomainService ds = ... // code to create a service, or look it up
                                   // from a container
    
            if (ds != null) {
                ds.Initialize(context);
            }
            return ds;
        }
        
        public void ReleaseDomainService(DomainService domainService) {
            // any custom logic that must be run to dispose a domain service
            domainService.Dispose();
        }
    }
