    public static class HtmlNodeTools
    {
        public static IEnumerable<string> MatchedKeywords(
            this HtmlNode nSearch,
                 IEnumerable<KeyValuePair<string, Regex>> keywordList)
        {
            // as regex
            var innerHtml = nSearch.InnerHtml;
            return from kvp in keywordList
                   where kvp.Value.IsMatch(innerHtml)
                   select kvp.Key;
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
            var keyworkSet = keyworkList.Select(kw => 
                new KeyValuePair<string, Regex>(kw, 
                                                new Regex(
                                                    @"\b" + kw + @"\b", 
                                                    RegexOptions.IgnoreCase)
                                                    )
                                                ).ToArray();
            var matched = h.MatchedKeywords(keyworkSet).ToList();
            //hello, world
        }
    }
