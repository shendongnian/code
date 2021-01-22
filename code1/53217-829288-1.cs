    string url = "http://www.somedomain.com/somepage.html"
        .AddQueryParam("A", "TheValueOfA")
        .AddQueryParam("B", "TheValueOfB")
        .AddQueryParam("Z", "TheValueOfZ");
 
    // ...
    public static string AddQueryParam(
        this string source, string key, string value)
    {
        if ((source == null) || !source.Contains("?"))
        {
            return source + "?" +
                HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(value);
        }
        else if (source.EndsWith("?") || source.EndsWith("&"))
        {
            return source +
                HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(value);
        }
        else
        {
            return source + "&" +
                HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(value);
        }
    }
