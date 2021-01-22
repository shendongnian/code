    string html;
    using (WebClient client = new WebClient()) {
        html = client.DownloadString("http://www.google.com");
    }
    HtmlDocument doc = new HtmlDocument();        
    doc.LoadHtml(html);
    foreach(HtmlNode img in doc.DocumentNode.SelectNodes("//img")) {
        Console.WriteLine(img.GetAttributeValue("src", null));
