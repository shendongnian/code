    [ServiceContract]
    public interface IMyService
    {
        [WebInvoke(Method = "PUT", 
            UriTemplate = "My/{name}/", 
            BodyStyle = WebMessageBodyStyle.Bare, 
            ResponseFormat = WebMessageFormat.Xml, 
            RequestFormat = WebMessageFormat.Xml)]
        [OperationContract]
        void PrintNameDesc(string name, string desc);
    }
