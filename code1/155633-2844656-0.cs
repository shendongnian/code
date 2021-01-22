    class Program
    {
        static void Main()
        {
            var document = new HtmlDocument();
            using (var client = new WebClient())
            using (var reader = new StringReader(client.DownloadString("http://www.google.com")))
            {
                document.Load(reader);
            }
    
            var anchors = document.DocumentNode.SelectNodes("//a");
            foreach (var anchor in anchors)
            {
                Console.WriteLine(anchor.Attributes["href"].Value);
            }
        }
    }
