    var proxy = WebProxyFactory.Create<ITitleWorldService>(url, userName, password);
    
    using (new OperationContextScope((IContextChannel)proxy))
    {
        var authorizationToken = GetBasicAuthorizationToken(userName, password);
        var httpRequestProperty = new HttpRequestMessageProperty();
        httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = authorizationToken;
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
        
        //var response = proxy.DoWork();    
        Console.WriteLine(proxy.SayHello());
    }
