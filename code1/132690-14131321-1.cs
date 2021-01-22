        private List<string> ParseLinks(string html)
        {
            var doc = new HtmlDocument(); 
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes("//a[@href]");
            return nodes == null ? new List<string>() : nodes.ToList().ConvertAll(r => r.Attributes.ToList().ConvertAll(i => i.Value)).SelectMany(j => j).ToList();
        }
