    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(File.ReadAllText("test.txt")); // here you can give a normal string
    foreach (var li in doc.DocumentNode.SelectNodes("//li")) // select li only
    {
        output += li.InnerText; // here do what you want to do
    }
