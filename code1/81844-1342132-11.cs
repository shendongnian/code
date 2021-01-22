    internal class PolicyServerSink : IServerChannelSink
    {
      public PolicyServerSink(
        IChannelReceiver receiver, IServerChannelSink nextSink)
      {
        NextChannelSink = nextSink;
      }
    
      public IDictionary Properties { get; private set; }
    
      public ServerProcessing ProcessMessage(
        IServerChannelSinkStack sinkStack, IMessage requestMsg,
        ITransportHeaders requestHeaders, Stream requestStream,
        out IMessage responseMsg, out ITransportHeaders responseHeaders,
        out Stream responseStream)
      {
        if (requestMsg != null || ! ShouldIntercept(requestHeaders))
          return NextChannelSink.ProcessMessage(
            sinkStack, requestMsg, requestHeaders, requestStream,
            out responseMsg, out responseHeaders, out responseStream);
    
        responseHeaders = new TransportHeaders();
        responseHeaders["Content-Type"] = "text/xml";
        responseStream = new MemoryStream(Encoding.UTF8.GetBytes(
          @"<?xml version=""1.0""?><!DOCTYPE cross-domain-policy SYSTEM "
          + @"""http://www.macromedia.com/xml/dtds/cross-domain-policy.dtd"">"
          + @"<cross-domain-policy><allow-access-from domain=""*"" />"
          + @"</cross-domain-policy>")) {Position = 0};
        responseMsg = null;
        return ServerProcessing.Complete;
      }
    
      private static bool ShouldIntercept(ITransportHeaders headers)
      {
        return ((string) headers["__RequestUri"]).Equals(
          "/crossdomain.xml", StringComparison.InvariantCultureIgnoreCase);
      }
    
      public void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack,
        object state, IMessage msg, ITransportHeaders headers, Stream stream)
      {
      }
    
      public Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack,
        object state, IMessage msg, ITransportHeaders headers)
      {
        throw new NotSupportedException();
      }
    
      public IServerChannelSink NextChannelSink { get; private set; }
    }
