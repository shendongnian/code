    void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
        foreach (OperationDescription operationDescription in endpoint.Contract.Operations)
        {
            foreach (MessageDescription msgDescription in operationDescription.Messages)
            {
                AddSoapHeader(operationDescription, "SomeHeaderObject", typeof(SomeHeaderObject), SoapHeaderDirection.InOut);
            }
        }
    }
    internal static void AddSoapHeader(OperationDescription operationDescription, string name, Type type, SoapHeaderDirection direction)
    {
        MessageHeaderDescription header = GetMessageHeader(name, type);
        bool input = ((direction & SoapHeaderDirection.In) == SoapHeaderDirection.In);
        bool output = ((direction & SoapHeaderDirection.Out) == SoapHeaderDirection.Out);
        foreach (MessageDescription msgDescription in operationDescription.Messages)
        {
                if ((msgDescription.Direction == MessageDirection.Input && input) ||
                        (msgDescription.Direction == MessageDirection.Output && output))
                        msgDescription.Headers.Add(header);
        }
    }
    internal static MessageHeaderDescription GetMessageHeader(string name, Type type)
    {
        string headerNamespace = SoapHeaderHelper.GetNamespace(type);
        MessageHeaderDescription messageHeaderDescription = new MessageHeaderDescription(name, headerNamespace);
        messageHeaderDescription.Type = type;
        return messageHeaderDescription;
    }
