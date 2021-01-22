    [ServiceContract]
    public interface IStatefulService
    { 
        [OperationContract]
        void KeepAlive(int sessionID);
    }
    [ServiceContract]
    public interface ICalculator : IStatefulService
    {
        [OperationContract]
        int Add(int a, int b);
    }
    [ServiceContract]
    public interface IEcho : IStatefulService
    {
        [OperationContract]
        string Echo(string message);
    }
