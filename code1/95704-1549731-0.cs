    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load("yourfile.xml");
    foreach (XmlNode result in xmlDoc.SelectNodes("/results/result"))
    {
        string title = result.SelectSingleNode("title").InnerText;
        string url = result.SelectSingleNode("url").InnerText;
        foreach (XmlNode insideLink in result.SelectNodes("inside_links/inside_link"))
        {
            string description = insideLink.SelectSingleNode("description").InnerText;
        }
    }
