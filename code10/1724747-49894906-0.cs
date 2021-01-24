    string Text = "Hello <co value=\"FF0000FF\">World!</co>";
    
    Text = System.Net.WebUtility.HtmlDecode(Text);
    HtmlDocument result = new HtmlDocument();
    result.LoadHtml(Text);
    
    List<HtmlNode> nodes = result.DocumentNode.Descendants().ToList();
