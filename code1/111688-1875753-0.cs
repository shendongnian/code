        private static IEnumerable<string> DocumentLinks(string sourceHtml)
        {
            HtmlDocument sourceDocument = new HtmlDocument();
            sourceDocument.LoadHtml(sourceHtml);
            return (IEnumerable<string>)sourceDocument.DocumentNode
                .SelectNodes("//a[@href!='#']")
                    .Select(n => n.GetAttributeValue("href",""));
        }
