    HtmlDocument docEmpty = new HtmlDocument();
    docEmpty.LoadHtml("<p><br /></p>");
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml("<p>I am not empty...<br /></p>");
    bool shouldBeEmpty = string.IsNullOrEmpty(docEmpty.DocumentNode.InnerText);
    bool shouldNotByEmpty = string.IsNullOrEmpty(doc.DocumentNode.InnerText);
