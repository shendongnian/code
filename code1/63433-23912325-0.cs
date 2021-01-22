    [DataContract(Name="MyHeader", Namespace="web")]
    public class MyHeader
    {
        [DataMember(Order=1)]
        public string UserName {get; set;}
        [DataMember(Order=2)]
        public string Password { get; set; }
    }
    [SoapHeaders]
    [ServiceContract]
    public interface IMyService
    {
        [SoapHeader("MyHeader", typeof(MyHeader), Direction = SoapHeaderDirection.In)]
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool MyMethod(string input);
    }
