    public static class StringEscapeUtils
    {
        public static string EscapeXml(string unescaped)
        {
            return SecurityElement.Escape(unescaped);
        }
        public static string UnescapeXml(string escaped)
        {
            return escaped.Replace("&quot;", "\"")
                          .Replace("&apos;", "'")
                          .Replace("&gt;", ">")
                          .Replace("&lt;", "<")
                          .Replace("&amp;", "&");
        }
        public static string EscapeHtml(string unescaped)
        {
            return HttpServerUtility.HtmlEncode(unescaped);
        }
        public static string UnescapeHtml(string escaped)
        {
            return HttpServerUtility.HtmlDecode(escaped);
        }
    }
