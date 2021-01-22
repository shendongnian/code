    public string AddImageLink(string emailBody,string imagePath)
    {
        try
        {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(emailBody);
        HtmlNode node = doc.DocumentNode.SelectSingleNode("//body");
        // get body using xpath query ("//body")
        // create the new node ..
        HtmlNodeCollection LinkNode = new HtmlNodeCollection(node);
        //
        HtmlNode linkNode = new HtmlNode(HtmlNodeType.Element,doc,0);
        linkNode.Name = "A";
        linkNode.Attributes.Add("href","www.splash-solutions.co.uk");
        HtmlNode imgNode = new HtmlNode(HtmlNodeType.Element,doc,1);
        imgNode.Name = "img";
        imgNode.Attributes.Add("src",imagePath);
        //appending the linknode with image node
        linkNode.AppendChild(imgNode);
        LinkNode.Append(linkNode);
        //appending LinkNode to the body of the html
        node.AppendChildren(LinkNode);
                
             
        StringWriter writer = new StringWriter();
        doc.Save(writer);
        emailBody = writer.ToString();
        return emailBody;
    }
