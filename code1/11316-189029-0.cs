    using Common;  
    [ServiceContract]
    [ServiceKnownType(typeof(MyEnum))]
    public interface IMyService
    {
        [OperationContract]
        ServiceMethod1( MyEnum e, string sUserId, string sSomeData);
    }
