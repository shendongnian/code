    public void MyServiceMethod()
    {
       var opContext = OperationContext.Current;
       var requestContext = opContext.RequestContext;
       var headers = requestContext.RequestMessage.Headers;
       int headerIndex = headers.FindHeader("ClientIdentification", "");
       var clientString = headers.GetHeader<string>(headerIndex);
       if clientString=="ASP_Client"
       {
           // ...
       }
       else
       {
          // ...
       }
    }
