    class Program
    {
        static void Main(string[] args)
        {
            string html = File.ReadAllText(@"Path to your html file");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var innerContent = doc.DocumentNode.SelectNodes("//div[contains(@class, 'test')]").Select(x => x.InnerHtml.Trim());
            foreach (var item in innerContent)
                Console.WriteLine(item);
            Console.ReadLine();
        }
    }
