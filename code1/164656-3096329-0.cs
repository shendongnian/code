    internal sealed class ServiceConstants {
       internal const string Namespace = "urn:example.com/~coolest/service/ever";
    } 
    [ServiceContract(Namespace=ServiceConstants.Namespace)]
    [WebService(Namespace=ServiceConstants.Namespace)]
    public sealed class MyService {}
    
