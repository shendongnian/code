    string url = "http://website.com";
    var Webget = new HtmlWeb();
    var doc = Webget.Load(url);
    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//h2//a"))
    {
      names.Add(node.ChildNodes[0].InnerHtml);
    }
    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//li[@class='tel']//a"))
    {
      phones.Add(node.ChildNodes[0].InnerHtml);
    }
