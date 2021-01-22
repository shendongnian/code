    HtmlDocument doc = new HtmlDocument();
    doc.Load(@"C:\Sample.HTM");
    HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//a/@href");
    
    Content match = null;
    
    // Run only if there are links in the document.
    if (linkNodes != null)
    {
        foreach (HtmlNode linkNode in linkNodes)
        {
            HtmlAttribute attrib = linkNode.Attributes["href"];
            // Do whatever else you need here
        }
    }
