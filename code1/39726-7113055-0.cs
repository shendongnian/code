    [ServiceContract]
    public interface IWcfPingTest
    {
      [OperationContract]
      string Ping();
    }
