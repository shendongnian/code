    private IDictionary<string, RequestToken> RequestTokens = 
       new Dictionary<string, RequestToken>();
    
    public MyResponse MyMethod(MyRequest request)
    {
       // get the MD5 for the request
       var md5 = GetMD5Hash(request);
    
       // check if another thread is processing/has processed an identical request
       RequestToken token;
       if (RequestTokens.TryGetValue(md5, out token))
       {
          // if the token exists already then wait till we can acquire the lock
          // which indicates the processing has finished and a response is ready
          // for us to reuse
          lock (token.Sync)
          {
             return token.Response;
          }
       }
       else
       {
          var token = new Token(md5);
          lock (token.Sync)
          {
             RequestToken.Add(md5, token);
    
             // do processing here..
             var response = ....
    
             token.Response = response;
    
             return response;
          }
       }
    }
    
    private class RequestToken
    {
       private readonly object _sync = new object();
    
       public RequestToken(string md5)
       {
          MD5 = md5;
       }
       public string MD5 { get; private set; }
    
       public object Sync { get { return _sync; } }
    
       public MyResponse Response { get; set; }
    }
