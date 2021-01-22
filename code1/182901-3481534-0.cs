    public static class StringExtensions
    {
        public static string HtmlEncode(this string dataString)
        {
            return HttpServerUtility.HtmlEncode(dataString);
        }
    }
