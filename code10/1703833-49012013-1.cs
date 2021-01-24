    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class DispatchByBodyBehaviorAttribute : Attribute, IContractBehavior
    {
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters){}
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime){}
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint){}
        
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            //We want the operator selector to be this
            dispatchRuntime.OperationSelector = new DispatchByBodyOperationSelector();
        }
    }
