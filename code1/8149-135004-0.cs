    WebRequest request = WebRequest.Create("http://something.somewhere/url");
    WebResponse response = null;
    request.Timeout = 10000; // 10 second timeout
    try
    {
        response = request.GetResponse();
    }
    catch(WebException e)
    {
      if( e.Status == WebExceptionStatus.Timeout)
      {
        //something
      }
    }
