    [ServiceContract]
    interface ILimitedAvailabilityOp
    {
        [OperationContract]
        string OpB();
    }
    
    [ServiceContract]
    interface IAllOfMyOps : ILimitedAvailabilityOp
    {
        [OperationContract]
        string OpA();
    }
