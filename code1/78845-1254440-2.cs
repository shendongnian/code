    [ServiceContract]
    public interface IWCFService
    {
        [OperationContract]
        int CheckHealth(int id);
    }
