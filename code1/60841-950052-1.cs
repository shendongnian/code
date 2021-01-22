    public ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, 
        IMessage requestmessage, ITransportHeaders requestHeaders, 
        System.IO.Stream requestStream, out IMessage responseMessage, 
        out ITransportHeaders responseHeaders, out System.IO.Stream responseStream)
    {
        // Get the IP address and add it to the call context.
        IPAddress ipAddr = (IPAddress)requestHeaders[CommonTransportKeys.IPAddress];
    }
