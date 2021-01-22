      public class InstanceInitializerBehavior : IEndpointBehavior
      {
    
        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters)
        {    }
    
        //Apply the custom IInstanceContextProvider to the EndpointDispatcher.DispatchRuntime
        public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
        {
          MyInstanceContextInitializer extension = new MyInstanceContextInitializer();
          endpointDispatcher.DispatchRuntime.InstanceContextInitializers.Add(extension);
        }
    
        public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
        {    }
    
        public void Validate(ServiceEndpoint endpoint)
        {    }
      }
