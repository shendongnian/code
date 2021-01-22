    public class CustomMessageInspector : System.ServiceModel.Dispatcher.IClientMessageInspector
    {
        public void AfterReceiveReply(ref WCF.Message reply, object correclationState)
        {
        }
        public Object BeforeSendRequest(ref WCF.Message request, IClientChannel channel)
        {
            MessageHeaders headers = new MessageHeaders(MessageVersion.Soap11WSAddressing10);
            MessageHeader header = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", "");
            request.Headers.Add(header);
            return null;
        }
    }
    public class CustomBehavior : System.ServiceModel.Description.IEndpointBehavior
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRunTime)
            {
                CustomMessageInspector inspector = new CustomMessageInspector();
                clientRunTime.MessageInspectors.Add(inspector);
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
            }
    
            public void Validate(ServiceEndpoint endpoint)
            {
            }
        }
