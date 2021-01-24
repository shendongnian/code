    private string DecodeString(string text)
    {
        Encoding targetEncoding = Encoding.GetEncoding("ISO-8859-1");
        var unescapeText = System.Text.RegularExpressions.Regex.Unescape(text);
        return Encoding.UTF8.GetString(targetEncoding.GetBytes(unescapeText));
    }
