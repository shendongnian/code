    private string ToQueryString(NameValueCollection nvc)
    {
      return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}",    
                                                                  HttpUtility.UrlEncode(key), 
                                                                  HttpUtility.UrlEncode(nvc[key]))));
    }
