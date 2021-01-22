    [ServiceContract(CallbackContract = typeof(IMyCallbackContract))]
    interface IMyContract
    {
        [OperationContract]
        void DoSomething();
    }
    interface IMyCallbackContract
    {
       [OperationContract]
       void OnCallback();
    }
