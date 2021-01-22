    [OperationContract]		
    public void LoginToApi(string username, string password, string clientName)
    {
  	// authenticate with DB, if successful ...
  	// construct a cookie
    	HttpCookie httpCookie = new HttpCookie("SessionID","whateverneeded");
    	HttpContext.Current.Response.SetCookie(httpCookie);
    }
