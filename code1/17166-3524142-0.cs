    public static string ToHtmlEncodedString(this string s)
    {
        if (String.IsNullOrEmpty(s))
            return s;
        return HttpUtility.HtmlEncode(s);
    }
