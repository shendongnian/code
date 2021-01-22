    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//h2//a"))
    {
      names.Add(node.ChildNodes[0].InnerHtml);
    }
    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//li[@class='tel']//a"))
    {
      phones.Add(node.ChildNodes[0].InnerHtml);
    }
