    public class MyOperationBehavior : IOperationBehavior
    {
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new MyOperationInvoker();
        }
    }
