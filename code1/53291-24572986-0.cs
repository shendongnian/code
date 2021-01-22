    private string ToQueryString(NameValueCollection nvc)
    {
        if (nvc == null) return String.Empty;
        var queryParams = 
              string.Join("&", nvc.AllKeys.Select(key => 
                  string.Join("&", nvc.GetValues(key).Select(v => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(v))))));
        return "?" + queryParams;
    }
