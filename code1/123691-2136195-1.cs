    class MessageInspectionBehavior : IClientMessageInspector, IEndpointBehavior
    {
        public void Validate(ServiceEndpoint endpoint)
        {
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //Write request message
            Console.WriteLine(request.ToString());
            return null;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            // Write out http headers
            foreach (var property in reply.Properties)
            {
                if (!(property.Value is HttpResponseMessageProperty)) continue;
                var httpProperties = (HttpResponseMessageProperty)property.Value;
                foreach (KeyValuePair<object, object> kvp in httpProperties.Headers)
                {
                    Console.WriteLine(kvp.Key + ":" + kvp.Value);
                }
            }
            // Write result message
            Console.WriteLine(reply.ToString());
        }
    }
