    public string ReplaceFontBySpan()
    {
        HtmlDocument doc = new HtmlDocument();
    
        string htmlContent = @"<font color='#000000'>Case 1</font><br />
    <font size=6>Case 2</font><br />
    <font color='red' size='12'>Case 3</font>";
    
        doc.LoadHtml(htmlContent);
    
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//font"))
        {
            var attributes = node.Attributes;
    
            foreach (var item in attributes)
            {
                if (item.Name.Equals("size"))
                {
                    item.Name = "font-size";
                    item.Value = item.Value + "rem";
                }
            }
    
            var attributeValueList = node.Attributes.Select(x => x.Name + ":" + x.Value).ToList();
    
            string attributeName = "style";
            string attributeValue = string.Join(";", attributeValueList);
    
    
            HtmlNode span = doc.CreateElement("span");
            span.Attributes.Add(attributeName, attributeValue);
            span.InnerHtml = node.InnerHtml;
    
            node.ParentNode.ReplaceChild(span, node);
        }
    
        return doc.DocumentNode.OuterHtml;
    }
