    public static string Get(string key)
    {
        object value = HttpContext.Current.Request.QueryString[key];
        return (value == null) ? null : value.ToString();
    }
