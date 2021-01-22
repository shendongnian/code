    private string ToQueryString(NameValueCollection nvc)
    {
        return "?" + string.Join("&", nvc.AllKeys.Select(k => string.Format("{0}={1}", 
            HttpUtility.UrlEncode(k), 
            HttpUtility.UrlEncode(nvc[k]))));
    }
