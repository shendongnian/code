    [ServiceContract(Namespace = "http://mycompany.com/Services/MyProduct")]
    public interface IService
    {
        [OperationContract]
        CompositeType GetData();
    }
    [DataContract(Namespace = "http://mycompany.com/Services/MyProduct")]
    public class CompositeType
    {
        // Whatever
    }
