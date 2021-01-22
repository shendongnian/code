    [ServiceContract(Namespace = "http://myUrl.com")]  
    public interface IMyWebService  
    {  
       [OperationContract]  
       string DoSomething(RequestMessage request);  
    }
    
    [DataContract]
    public class RequestMessage
    {
       [DataMember(IsRequired = true)]
       public string param1 { get; set; }
    
       [DataMember(IsRequired = true)]
       public string param3 { get; set; }
    
       [DataMember(IsRequired = true)]
       public string param3 { get; set; }
    }
