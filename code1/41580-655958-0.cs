    [ServiceContract(Namespace = "yyyWCF")]     
    public interface IClientBroker
    {
        [OperationContract]
        [ServiceKnownType(typeof(Client))]
        [WebInvoke(
            Method="GET",
            BodyStyle=WebMessageBodyStyle.WrappedRequest,
            ResponseFormat=WebMessageFormat.Json)]
        IClient GetClientJson(int clientId);
    
    }
