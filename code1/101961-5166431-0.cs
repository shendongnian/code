    public static string ConstructQueryString(NameValueCollection parameters)
    {
        var sb = new StringBuilder();
        foreach (String name in parameters)
            sb.Append(String.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name]), "&"));
        if (sb.Length > 0)
            return sb.ToString(0, sb.Length - 1);
        return String.Empty;
    } 
