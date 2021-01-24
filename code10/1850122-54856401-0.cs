     public static async Task Main(string[] args)
     {
        List<WordCls> wordList = new List<WordCls>();
        IBrowsingContext context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
        Url url = Url.Create("http://1000mostcommonwords.com/1000-most-common-afrikaans-words");
        IDocument doc = await context.OpenAsync(url);
        IElement tableElement = doc.QuerySelector("table");
        var trs = tableElement.QuerySelectorAll("tr");
        foreach (IElement tr in trs.Next(selector: null))
        {
            var tds = tr.QuerySelectorAll("td");
            WordCls word = new WordCls
            {
                Number = Convert.ToInt32(tds[0].Text()),
                African = tds[1].Text(),
                English = tds[2].Text()
            };
            wordList.Add(word);
        }
        Console.WriteLine(wordList.Count);
    }
    
---
    public class WordCls
    {
        public int Number { get; set; }
        public string African { get; set; }
        public string English { get; set; }
    }
