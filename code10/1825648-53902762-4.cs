       static public StringBuilder Content { get; set; }
        static void Main(string[] args)
        {
            string html;
            Content = new StringBuilder();
            string url = @"https://www.msn.com/en-gb/news/uknews/universal-credit-forcing-families-to-wait-months-for-help-to-pay-childcare-bills-mps-warn/ar-BBRjFtR?li=BBoPRmx";
            WebClient wc = new WebClient();
            HtmlDocument doc = new HtmlDocument();
            html = wc.DownloadString(url);
            doc.LoadHtml(html);
            var allP = doc.DocumentNode.SelectNodes("//p");
            var allLink = doc.DocumentNode.SelectNodes("//a");
            foreach (var p in allP)
            {
                var outerHtml = p.OuterHtml;
                List<string> potentialContent = Regex.Replace(outerHtml, "<[^>]*>", "").Split(' ').ToList();
                if (potentialContent.Count > 1)
                {
                    Content.Append(new StringBuilder(string.Join(" ", potentialContent)));
                }
            }
            foreach (var p in allLink)
            {
                var outerHtml = p.OuterHtml;
                List<string> potentialContent = Regex.Replace(outerHtml, "<[^>]*>", "").Split(' ').ToList();
                if (potentialContent.Count > 1)
                {
                    Content.Append(new StringBuilder(string.Join(" ", potentialContent)));
                }
            }
        }
