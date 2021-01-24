        public static class HtmlAgilityPackExtensions
    {
        public static string InnerHtmlDecode(this HtmlNode htmlNode)
        {
            return System.Net.WebUtility.HtmlDecode(htmlNode.InnerHtml);
        }
    }
