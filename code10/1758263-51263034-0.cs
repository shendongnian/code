    HttpClient _client;
    public void InitTheClient()
    {
        var handler=new WebRequestHandler
                    { 
                        UseDefaultCredentials=true,
                        UnsafeAuthenticatedConnectionSharing =true
                    };
        _client=new HttpClient(handler); 
    }
