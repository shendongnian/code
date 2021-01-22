    string url = "http://www.somedomain.com/somepage.html"
        .AddQueryParam("A", "TheValueOfA")
        .AddQueryParam("B", "TheValueOfB")
        .AddQueryParam("Z", "TheValueOfZ");
 
    // ...
    public static string AddQueryParam(
        this string source, string key, string value)
    {
        string format;
        if ((source == null) || !source.Contains("?"))
        {
            format = "{0}?{1}={2}";
        }
        else if (source.EndsWith("?") || source.EndsWith("&"))
        {
            format = "{0}{1}={2}";
        }
        else
        {
            format = "{0}&{1}={2}";
        }
        return string.Format(format, source,
            HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value));
    }
