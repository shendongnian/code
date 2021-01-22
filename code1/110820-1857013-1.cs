    string url = client.Url;
    try
    {
      client.MyWebServiceCall();
      url = client2.Url;
      client2.MyWebServiceCall2();
    }
    catch (Exception ex)
    {
      throw new Exception("Webservice call failed. Url: "+url+", Error:"+ex.Message,ex);
    }
