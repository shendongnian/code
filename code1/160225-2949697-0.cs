    [ServiceContract]
    public interface ICallbackBase
    {
        [OperationContract]
        void CommonlyUsedMethod();
    }
    
    [ServiceContract]
    public interface ICallback1 : ICallbackBase
    {
        [OperationContract]
        void SpecificMethod();
    }
