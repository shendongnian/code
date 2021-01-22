    public static class HttpClientExt
    {
        public static Uri AddQueryString(this Uri uri, string query)
        {
            var ub = new UriBuilder(uri);
            ub.Query = string.IsNullOrEmpty(uri.Query) ? query : string.Join("&", uri.Query.Substring(1), query);
            return ub.Uri;
        } 
        public static Uri AddQueryParam(this Uri uri, string key, string value)
        {
            return uri.AddQueryString(string.Join("=", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)));
        }
        public static Uri AddQueryParams(this Uri uri, params KeyValuePair<string,string>[] kvps)
        {
            return uri.AddQueryString(string.Join("&", kvps.Select(kvp => string.Join("=", HttpUtility.UrlEncode(kvp.Key), HttpUtility.UrlEncode(kvp.Value)))));
        }
        public static Uri AddQueryParams(this Uri uri, NameValueCollection nvc)
        {
            return uri.AddQueryString(string.Join("&", nvc.AllKeys.SelectMany(nvc.GetValues, (key, value) => string.Join("=", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))));
        }
    }
