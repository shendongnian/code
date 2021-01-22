    public class MyServiceBehavior : Attribute, IServiceBehavior
    {
        public void ApplyDispatchBehavior( ServiceDescription serviceDescription,
            ServiceHostBase serviceHostBase )
        {
            foreach( ChannelDispatcher cDispatcher in serviceHostBase.ChannelDispatchers )
                foreach( EndpointDispatcher eDispatcher in cDispatcher.Endpoints )
                    eDispatcher.DispatchRuntime.MessageInspectors.Add( new RequestAuthChecker() );
        }
    }
