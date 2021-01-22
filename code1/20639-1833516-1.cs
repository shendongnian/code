    public class ErrorHandler : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
        }
        public bool HandleError(Exception error)
        {
            Console.WriteLine("exception");
            return false;
        }
    }
    public class ErrorServiceBehavior : IServiceBehavior
    {
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            ErrorHandler handler = new ErrorHandler();
            foreach (ChannelDispatcher dispatcher in serviceHostBase.ChannelDispatchers)
            {
                dispatcher.ErrorHandlers.Add(handler);
            }
        }
    }
        
    ServiceHost host = new ServiceHost(new Service.MyService());
    host.Faulted += new EventHandler(host_faulted);
    host.Description.Behaviors.Add(new ErrorServiceBehavior());
    host.Open();
