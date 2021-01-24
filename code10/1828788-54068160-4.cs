    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
                [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SayHello", ReplyAction="http://tempuri.org/IService/SayHelloResponse")]
        [WebGet]
        string SayHello();
