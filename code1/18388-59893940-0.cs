    public static class StringExtensions
    {
        public static string ConvertToPlain(this string html)
        {
            if (html == null)
            {
                return html;
            }
            html = scriptRegex.Replace(html, string.Empty);
            html = inlineTagRegex.Replace(html, string.Empty);
            html = tagRegex.Replace(html, " ");
            html = HttpUtility.HtmlDecode(html);
            html = multiWhitespaceRegex.Replace(html, " ");
            return html.Trim();
        }
        private static readonly Regex inlineTagRegex = new Regex("<\\/?(a|span|sub|sup|b|i|strong|small|big|em|label|q)[^>]*>", RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex scriptRegex = new Regex("<(script|style)[^>]*?>.*?</\\1>", RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex tagRegex = new Regex("<[^>]+>", RegexOptions.Compiled | RegexOptions.Singleline);
        private static readonly Regex multiWhitespaceRegex = new Regex("\\s+", RegexOptions.Compiled | RegexOptions.Singleline);
    }
