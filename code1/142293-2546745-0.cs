    public static class HtmlNodeTools
    {
        public static IEnumerable<string> MatchedKeywords(
            this HtmlNode nSearch,
                 IEnumerable<string> keywordList)
        {
            //// as regex
            //var innerHtml = nSearch.InnerHtml;
            //return keywordList.Where(kw =>
            //       Regex.IsMatch(innerHtml, 
            //                     @"\b" + kw + @"\b",
            //                     RegexOptions.IgnoreCase)
            //        );
            //would be faster if you don't need the pattern matching
            var innerHtml = ' ' + nSearch.InnerHtml + ' ';
            return keywordList.Where(kw => innerHtml.Contains(kw));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var keyworkList = new string[] { "hello", "world", "nomatch" };
            var h = new HtmlNode()
            {
                InnerHtml = "hi there hello other world"
            };
            var matched = h.MatchedKeywords(keyworkList).ToList();
            //hello, world
        }
    }
