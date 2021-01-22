    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                string data = client.DownloadString("http://www.google.com");
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(data);
                var nodes = doc.DocumentNode.SelectNodes("//a[@href]");
                foreach(HtmlNode link in nodes)
                {
                    HtmlAttribute att = link.Attributes["href"];
                    Console.WriteLine(att.Value);
                }
            }
        }
    }
