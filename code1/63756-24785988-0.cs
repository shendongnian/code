    [OperationContract]
    [WebGet(UriTemplate = "foo")]
    void Foo()
    {
       HttpContext.Current.Response.Write("bar");
    }
