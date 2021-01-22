    public static string ToQueryString(this NameValueCollection source)
    {
        return String.Join("&", source.AllKeys
            .SelectMany(key => source.GetValues(key)
                .Select(value => String.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value))))
            .ToArray());
    }
