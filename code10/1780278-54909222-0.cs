    public class EndpointLoggingBehavior : IEndpointBehavior
        {
            public EndpointLoggingBehavior(string serviceName)
            {
                _serviceName = serviceName;
            }
    
            private readonly string _serviceName;
    
            public void AddBindingParameters(ServiceEndpoint endpoint,
                System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
                clientRuntime.ClientMessageInspectors.Add(new MessageLoggingInspector(_serviceName));
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
            }
    
            public void Validate(ServiceEndpoint endpoint)
            {
            }
        }
