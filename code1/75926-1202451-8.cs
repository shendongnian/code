    [ServiceContract(Namespace = "http://company.com/MyCompany.Services.MyProduct")]
    public interface IService
    {
        [OperationContract]
        CompositeType GetData();
    }
    [DataContract(Namespace = "http://company.com/MyCompany.Services.MyProduct")]
    public class CompositeType
    {
        // Whatever
    }
