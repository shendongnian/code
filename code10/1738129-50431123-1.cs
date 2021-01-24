            HttpClient client = new HttpClient();
            var docResult = client.GetStringAsync("http://proxy-list.org/spanish/search.php?search=&country=any&type=any&port=any&ssl=any").Result;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(docResult);
            Regex reg = new Regex(@"Proxy\('(?<value>.*?)'\)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var stuff = doc.DocumentNode.SelectSingleNode("//div[@class='table']")
            .Descendants("li")
            .Where(x => x.HasClass("proxy"))
            .Select(li =>
            {
                return li.InnerText;
            }).ToList();
            foreach (var item in stuff)
            {
                var match = reg.Match(item);
                var proxy = Encoding.Default.GetString(System.Convert.FromBase64String(match.Groups["value"].Value));
                Console.WriteLine($"{item}\t\tproxy = {proxy}");
            }
