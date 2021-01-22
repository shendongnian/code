    var doc = new HtmlWeb().Load(url);
    var linkTags = doc.DocumentNode.Descendants("link");
    var linkedPages = doc.DocumentNode.Descendants("a")
                                      .Select(a => a.GetAttributeValue("href", null)
                                      .Where(u => !String.IsNullOrEmpty(u));
