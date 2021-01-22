    public static class StringEscapeUtils
    {
        public static string EscapeXml(string unescaped)
        {
            return SecurityElement.Escape(unescaped);
        }
        public static string UnescapeXml(string escaped)
        {
            return escaped.Replace("&lt;", "<")
                          .Replace("&gt;", ">")
                          .Replace("&quot;", "\"")
                          .Replace("&apos;", "'")
                          .Replace("&amp;", "&");
        }
        public static string EscapeHtml(string unescaped)
        {
            return HttpUtility.HtmlEncode(unescaped);
        }
        public static string UnescapeHtml(string escaped)
        {
            return HttpUtility.HtmlDecode(escaped);
        }
    }
