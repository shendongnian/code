    public static string RemoveHtmlTags(this string html)
    {
            if (String.IsNullOrEmpty(html))
                return html;
    
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
    
            if (doc == null || doc.DocumentNode == null)
            {
                return WebUtility.HtmlDecode(html);
            }
    
            var sb = new StringBuilder();
    
            var i = 0;
    
            foreach (var node in doc.DocumentNode.ChildNodes)
            {
                var text = node.InnerText.SafeTrim();
    
                if (!String.IsNullOrEmpty(text))
                {
                    sb.Append(text);
    
                    if (i < doc.DocumentNode.ChildNodes.Count - 1)
                    {
                        sb.Append(Environment.NewLine);
                    }
                }
    
                i++;
            }
    
            var result = sb.ToString();
    
            return WebUtility.HtmlDecode(result);
    }
    
    public static string SafeTrim(this string str)
    {
        if (String.IsNullOrEmpty(str))
            return null;
    
        return str.Trim();
    }
