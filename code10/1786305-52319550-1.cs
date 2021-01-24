    public class MyHandler
    {
        private static ConcurrentDictionary<string, Regex> dict = new ConcurrentDictionary<string, Regex>();
        public void Handle(string urlPattern)
        {
            urlPattern = urlPattern.Trim();
            var regex = dict.GetOrAdd(urlPattern, s => new Regex(urlPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));
            // use regex
        }
    }
