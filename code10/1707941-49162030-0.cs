    using HtmlAgilityPack;
    // Create the HtmlAgilityPack Document
    HtmlDocument Document = new HtmlDocument();
    // Fill the Document
    Document.LoadHtml(html);
    // use the below function to load the Containing Node
    HtmlNode StartExNode = getStartExNode(Document);
    // Load the Button using the function below
    string Button = getButton(StartExNode);
    public HtmlNode getStartExNode(HtmlDocument Document)
    {
        return Document // return the HtmlNode
            .DocumentNode
            .Descendants("div") // Get all descendants of the type div
            .Where(d =>
                d.Attributes.Contains("title") && // that conatin a title (you need to check to avoid null exceptions from the next query)
                d.Attributes["title"].Value.Contains("Start Examination") // the title must match "Start Examination" 
            );
    }
    
    public string getButton(HtmlNode Node)
    {
        return Node // Return button as string
            .Descendants("button") // get all descendants of type button
            .FirstOrDefault() // if there are more, use the first (more check to implement here)
            .OuterHtml;
    }
