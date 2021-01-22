    public static class HttpClientExt
    {
        public static Uri AddQueryParam(this Uri uri, string key, string value)
        {
            var ub = new UriBuilder(uri);
            var q = string.Join("=", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value));
            ub.Query = string.IsNullOrEmpty(uri.Query) ? q : string.Join("&", uri.Query.Substring(1), q);
            return ub.Uri;
        }
        public static Uri AddQueryParams(this Uri uri, NameValueCollection nvc)
        {
            var ub = new UriBuilder(uri);
            var q = string.Join("&",
                nvc.Cast<string>()
                    .Select(key => string.Join("=", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
            ub.Query = string.IsNullOrEmpty(uri.Query) ? q : string.Join("&",uri.Query.Substring(1), q);
            return ub.Uri;
        }
    }
