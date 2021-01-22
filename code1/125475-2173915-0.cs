    WebClient client = new WebClient();
    string url = "http://www.alexa.com/topsites/category/Top/Society/History/By_Topic/Science/Engineering_and_Technology";
    string source = client.DownloadString(url);
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(source);
    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href and @rel='nofollow']"))
    {
        HtmlAttribute att = link.Attributes["href"];
        Console.WriteLine(att.Value);
    }
