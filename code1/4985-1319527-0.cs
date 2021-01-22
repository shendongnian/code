    public ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, 
        IMessage requestmessage, ITransportHeaders requestHeaders, 
        System.IO.Stream requestStream, out IMessage responseMessage, 
        out ITransportHeaders responseHeaders, out System.IO.Stream responseStream)
    {
        try
        {
            // Get the IP address and add it to the call context.
            IPAddress ipAddr = (IPAddress)requestHeaders[CommonTransportKeys.IPAddress];
            CallContext.SetData("ClientIP", ipAddr);
        }
        catch (Exception)
        {
        }
    
        sinkStack.Push(this, null);
        ServerProcessing srvProc = _NextSink.ProcessMessage(sinkStack, requestmessage, requestHeaders,
            requestStream, out responseMessage, out responseHeaders, out responseStream);
    
        return srvProc;
    }
