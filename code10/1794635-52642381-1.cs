    public string ReplaceFontBySpan()
    {
        HtmlDocument doc = new HtmlDocument();
    
        string htmlContent = @"<font color='#000000'>Case 1</font><br />
    <font size=6>Case 2</font><br />
    <font color='red' size='12'>Case 3</font>";
    
        doc.LoadHtml(htmlContent);
    
        foreach (HtmlNode tb in doc.DocumentNode.SelectNodes("//font"))
        {
            var attributes = tb.Attributes;
    
            foreach (var item in attributes)
            {
                if (item.Name.Equals("size"))
                {
                    item.Name = "font-size";
                    item.Value = item.Value + "rem";
                }
            }
    
            var list = tb.Attributes.Select(x => x.Name + ":" + x.Value).ToList();
    
            var str = string.Join(";", list);
    
    
            HtmlNode span = doc.CreateElement("span");
            span.Attributes.Add("style", str);
            span.InnerHtml = tb.InnerHtml;
    
            tb.ParentNode.ReplaceChild(span, tb);
        }
    
        return doc.DocumentNode.OuterHtml;
    }
