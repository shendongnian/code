    HtmlGenericControl li = new HtmlGenericControl("li");
    ul.Controls.Add(li);
    HtmlGenericControl anchor = new HtmlGenericControl("a");
    anchor.Attributes.Add("href", "page.htm");
    anchor.InnerText = "TabX";
    
    li.Controls.Add(anchor);
