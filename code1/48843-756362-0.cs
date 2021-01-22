    [ServiceContract]
    public interface  IWebGui
    {
        [OperationContract]
        [WebGet(UriTemplate= "/")]
        Stream GetGrid();
    }
