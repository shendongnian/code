    [ServiceContract]
    [ServiceKnownType("GetServiceKnownTypes", typeof(KnownTypeHelper))]
    public interface IContract
    {
        [OperationContract]
        void Send(object data);
    }
    [DataContract]
    public class MyData
    {
        [DataMember]
        public string Message { get; set; }
    }
