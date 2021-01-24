    public class DefaultDependencyResolver :
        System.Web.Http.Dependencies.IDependencyResolver,
        System.Web.Mvc.IDependencyResolver {
        private readonly IServiceProvider serviceProvider;
    
        public DefaultDependencyResolver(IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }    
    
        public object GetService(Type serviceType) {
            return this.serviceProvider.GetService(serviceType);
        }
    
        public IEnumerable<object> GetServices(Type serviceType) {
            return this.serviceProvider.GetServices(serviceType);
        }
    
        //Web API specific
    
        public System.Web.Http.Dependencies.IDependencyScope BeginScope() {
            return this;
        }
    
        public void Dispose() {
            // NO-OP, as the container is shared. 
        }
    }
