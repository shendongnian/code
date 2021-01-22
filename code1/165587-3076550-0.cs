    public class MockOperationBehavior : BehaviorExtensionElement,  IOperationBehavior, IEndpointBehavior
    {
      public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
      {
         foreach (var op in endpoint.Contract.Operations)
         {
             op.Behaviors.Add(this);
         }
      }
    }
