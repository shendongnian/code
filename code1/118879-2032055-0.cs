    string EscapeXml(string unescaped)
    {
        return SecurityElement.Escape(unescaped);
    }
    string UnescapeXml(string escaped)
    {
        return escaped.Replace("&quot;", "\"")
                      .Replace("&apos;", "'")
                      .Replace("&gt;", ">")
                      .Replace("&lt;", "<")
                      .Replace("&amp;" "&");
    }
    string EscapeHtml(string unescaped)
    {
        return HttpServerUtility.HtmlEncode(unescaped);
    }
    string UnescapeHtml(string escaped)
    {
        return HttpServerUtility.HtmlDecode(escaped);
    }
