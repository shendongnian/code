    [WebGet(UriTemplate = "objects", BodyStyle = WebMessageBodyStyle.Bare)]
    [OperationContract]
    List<SampleObject> GetObjects();
    [WebGet(UriTemplate = "objects?format=json", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
    [OperationContract]
    List<SampleObject> GetObjectsInJson();
