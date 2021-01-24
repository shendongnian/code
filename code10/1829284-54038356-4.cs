    public class SimpleIocResolver : IDependencyResolver {
        protected ISimpleIoc container;
        public SimpleIocResolver(ISimpleIoc container) {
            if (container == null) {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }
        public object GetService(Type serviceType) {
            try {
                return container.GetInstance(serviceType);
            } catch(Exception) {
                return null;
            }
        }
        public IEnumerable<object> GetServices(Type serviceType) {
            try {
                return container.GetAllInstances(serviceType);
            } catch (Exception) {
                return new List<object>();
            }
        }
        public IDependencyScope BeginScope() {
            return new SimpleIocResolver(container);
        }
        public void Dispose() {
            //No Op
        }
    }
    
