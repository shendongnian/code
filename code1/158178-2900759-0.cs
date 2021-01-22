    [ServiceContract]
    public interface IServer
    {
        [OperationContract]
        Person GetPerson();
        [OperationContract]
        void UpdatePerson( Person person )
    }
    
