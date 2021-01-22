    public partial class MyServiceHost : ServiceBase {
        // details elided
        protected override void OnStart(string[] args) {
                this.Host = new ServiceHost(typeof(MySerivce));
                this.Host.Description.Behaviors.Add(new MyServiceBehavior());
                this.Host.Open();
        }
    }
    public class MyServiceBehavior : IServiceBehavior {
        public void AddBindingParameters(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters
        ) { }
        public void ApplyDispatchBehavior(
            ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase) {
                IIoCContainer container = new IocContainer();
                foreach (var cdBase in serviceHostBase.ChannelDispatchers) {
                    ChannelDispatcher cd = cdBase as ChannelDispatcher;
                    if (cd != null) {
                        foreach (EndpointDispatcher ed in cd.Endpoints) {
                            ed.DispatchRuntime.InstanceProvider = new MyInstanceProvider(
                                container,
                                serviceDescription.ServiceType
                            );
                        }
                    }
                }
            }
        public void Validate(
            ServiceDescription serviceDescription, 
            ServiceHostBase serviceHostBase
        ) { }
    }
    public class MyInstanceProvider : IInstanceProvider {
        readonly IIocContainer _container;
        readonly Type _serviceType;
        
        public InstanceProvider(IIoCContainer container, Type serviceType) {
            _container = container;
            _serviceType = serviceType;
        }
        public object GetInstance(InstanceContext instanceContext, Message message) {
            return _container.Resolve(_serviceType);
        }
        public object GetInstance(InstanceContext instanceContext) {
            return GetInstance(instanceContext, null);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance) { }       
    }
