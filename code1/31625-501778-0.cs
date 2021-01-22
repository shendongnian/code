    const string RECENT_QUESTIONS = "http://stackoverflow.com/feeds";
    
    XmlTextReader reader;
    XmlDocument doc;
    
    // Load the feed in
    reader = new XmlTextReader(RECENT_QUESTIONS);
    //reader.MoveToContent();
    
    // Add the feed to the document
    doc = new XmlDocument();
    doc.Load(reader);
    
    // Get the <feed> element.
    XmlNodeList feed = doc.GetElementsByTagName("feed");
    XmlNode feedNode = feed.Item(0);
    // Get the child nodes of the <feed> element.
    XmlNodeList childNodes = feedNode.ChildNodes;
    IEnumerator ienum = childNodes.GetEnumerator();
    List<XmlNode> entries = new List<XmlNode>();
    // Iterate over the child nodes.
    while (ienum.MoveNext())
    {
        XmlNode node = (XmlNode)ienum.Current;
        if (node.Name == "entry")
        {
            entries.Add(node);
        }
    }
    
    // Send entries to the data grid control
    question_list.DataSource = entries.ToArray();
