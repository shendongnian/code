    var links = h1.Cast<string>().Select(l => new HyperLink() { NavigateUrl = l, Text = l })
    
    foreach (var link in links)
    {
        this.Panel1.Controls.Add(link);
        this.Panel1.Controls.Add(new LiteralControl("<br/>");
    }
