    // Where m_whitespaceRegex is a Regex with [\s].
    // Where sampleHtmlText is a raw HTML string.
    
    var extractedSampleText = new StringBuilder();
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(sampleHtmlText);
    
    if(doc != null && doc.DocumentNode != null)
    {
        foreach(var script in doc.DocumentNode.Descendants("script").ToArray())
        {
            script.Remove();
        }
    
        foreach(var style in doc.DocumentNode.Descendants("style").ToArray())
        {
            style.Remove();
        }
    
        var allTextNodes = doc.DocumentNode.SelectNodes("//text()");
        if(allTextNodes != null && allTextNodes.Count > 0)
        {
            foreach(HtmlNode node in allTextNodes)
            {
                extractedSampleText.Append(node.InnerText);
            }
        }
    
        var finalText = m_whitespaceRegex.Replace(extractedSampleText.ToString(), " ");
    }
