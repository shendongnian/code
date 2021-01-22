    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IService1
    {
      [OperationContract]
      string AddData(int value);
    }
