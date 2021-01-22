    [ServiceContract]
    public interface ITestService : IDisposable
    {
        [OperationContract]
        string GetData(int value);
    }
