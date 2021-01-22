       HtmlDocument htmldoc = new HtmlDocument();
        htmldoc.LoadHtml(content);
        HtmlNodeCollection linkNodes = htmldoc.DocumentNode.SelectNodes("//a[@href]");
        if (linkNodes != null)
        {
            foreach (HtmlNode linkNode in linkNodes)
            {
                string linkTitle = linkNode.GetAttributeValue("title", string.Empty);
                //If no title attribute exists check for an image alt tag
                if (linkTitle == string.Empty)
                {
                    HtmlNode imageNode = linkNode.SelectSingleNode("img[@alt]");
                    if (imageNode != null)
                    {
                        linkTitle = imageNode.GetAttributeValue("alt", string.Empty);
                    }
                }
                //If no image alt tag check for span with text
                if (linkTitle == string.Empty)
                {
                    HtmlNode spanNode = linkNode.SelectSingleNode("span");
                    if (spanNode != null)
                    {
                        linkTitle = spanNode.InnerText;
                    }
                }
    
                if (linkTitle == string.Empty)
                {
                    if (!linkNode.HasChildNodes)
                    {
                        linkTitle = linkNode.InnerText;
                    }
                }
               
            }
        }
