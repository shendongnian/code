    [ServiceContract]
    public interface IService1 {
        [OperationContract]
        Task<string> GetData();
    }
    
