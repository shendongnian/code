    public class SimpleIocResolver : IDependencyResolver {
        protected ISimpleIoc container;
        public SimpleIocResolver(ISimpleIoc container) {
            if (container == null) {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }
        public object GetService(Type serviceType) {
            return container.GetInstance(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType) {
            return container.GetAllInstances(serviceType);
        }
        public IDependencyScope BeginScope() {
            return new SimpleIocResolver(container);
        }
        public void Dispose() {
            //No Op
        }
    }
    
