    [ServiceContract(Namespace = "http://www.TextXYZ.com/FUNC/1/0/action")]
    public interface IMyServiceContract
    {
        [OperationContract]
        void MyMethod();
    }
