        public class TMServerBehavior : IServiceBehavior {
    
            public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters) {
                //Do nothing
            }
    
            public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase) {
    
                foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers) {
    
                    foreach (EndpointDispatcher epDisp in chDisp.Endpoints) {
                        epDisp.DispatchRuntime.MessageInspectors.Add(new TMMessageInspector());
                    }
                }
    
            }
    }
