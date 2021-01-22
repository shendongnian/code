    [OperationContract,
    WebInvoke(Method="POST",
        BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Xml,
        ResponseFormat = WebMessageFormat.Xml,
        UriTemplate = "query")]
    XElement Query_Post(string qry);
    [OperationContract,
    WebInvoke(Method="GET",
        BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Xml,
        ResponseFormat = WebMessageFormat.Xml,
        UriTemplate = "query?query={qry}")]
    XElement Query_Get(string qry);
