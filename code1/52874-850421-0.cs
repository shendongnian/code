    [ServiceContract]
    public interface IService1
    {
        string Name
        {
            [OperationContract]
            get;
        }
    }
