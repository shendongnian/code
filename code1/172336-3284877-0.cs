    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/{*arguments}", Method="GET", BodyStyle=WebMessageBodyStyle.Bare)]
        Stream Get(string arguments);
    }
