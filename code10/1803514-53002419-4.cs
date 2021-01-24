    public string ReplaceSpanByB()
    {
        HtmlDocument doc = new HtmlDocument();
        string htmlContent = File.ReadAllText(@"C:\Users\xxx\source\repos\ConsoleApp4\ConsoleApp4\Files\HTMLPage1.html");
        doc.LoadHtml(htmlContent);
        if (doc.DocumentNode.SelectNodes("//span") != null)
        {
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span"))
            {
                var attributes = node.Attributes;
                foreach (var item in attributes)
                {
                    if (item.Name.Equals("style") && item.Value.Contains("font-weight"))
                    {
                        HtmlNode b = doc.CreateElement("b");
                        b.InnerHtml = node.InnerHtml;
                        node.ParentNode.ReplaceChild(b, node);
                    }
                }
            }
        }
        return doc.DocumentNode.OuterHtml;
    }
