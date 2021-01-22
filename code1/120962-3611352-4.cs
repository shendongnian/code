    public class GenericClientInspectorBehavior : IEndpointBehavior
    {
        public IClientMessageInspector Inspector { get; private set; }
        public GenericClientInspectorBehavior( IClientMessageInspector inspector )
        { Inspector = inspector; }
        // Empty methods excluded for brevity
        public void ApplyClientBehavior( ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime )
        { clientRuntime.MessageInspectors.Add( Inspector ); }
    }
