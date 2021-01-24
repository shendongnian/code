    [ServiceContract(Name = nameof(IMyService))]
    public interface IMyService : IMySubService1, IMySubService2
    {
    }
    
    [ServiceContract(Name = nameof(IMyService))]
    public interface IMySubService1
    {
        [OperationContract]
        int Method1();
    }
    
    [ServiceContract(Name = nameof(IMyService))]
    public interface IMySubService2
    {
        [OperationContract]
        int Method2();
    }
