    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IMyContract
    {
        [OperationContract(IsOneWay = true)]
        void Update(myClass[] stuff);
    }
