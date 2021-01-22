    using System.Web;
    using System.Collections.Specialized;
    private string ToQueryString(NameValueCollection nvc)
    {
        var array = (from key in nvc.AllKeys
            from value in nvc.GetValues(key)
            select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
            .ToArray();
        return "?" + string.Join("&", array);
    }
