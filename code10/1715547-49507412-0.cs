        class Program
    {
        static void Main(string[] args)
        {
            var html = System.IO.File.ReadAllText(@"index.html");
            var doc = new HtmlAgilityPack.HtmlDocument
            {
                OptionFixNestedTags = true,
                OptionCheckSyntax = true,
                OptionAutoCloseOnEnd = true
            };
            doc.LoadHtml(html);
            var results =
            doc.DocumentNode.SelectSingleNode("//table[@class='MyClass']")
            .Descendants("tr")
            .Skip(1) //To Skip Table Header Row
            .Where(tr => tr.Elements("td").Count() > 1)
            .Select(tr =>
            {
                return new Result
                {
                    link = tr.Elements("td").Select(td => td.Elements("a").FirstOrDefault().Attributes["href"].Value).FirstOrDefault(),
                    inner = tr.Elements("td").Select(td => td.Elements("a").FirstOrDefault().InnerText).FirstOrDefault(),
                    name = tr.Elements("td").Skip(1).FirstOrDefault().InnerText
                };
            });
            foreach (var result in results)
            {
                Console.WriteLine($"Link: {result.link} InnerText: {result.inner} Name: {result.name}");
            }
        }
    }
    class Result
    {
        public string link { get; set; }
        public string inner { get; set; }
        public string name { get; set; }
    }
