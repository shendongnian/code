    public static XNode createNodeFromXPath(XElement elem, string xpath)
    {
        // Create a new Regex object
        Regex r = new Regex(@"/*([a-zA-Z0-9_\.\-]+)(\[@([a-zA-Z0-9_\.\-]+)='([^']*)'\])?|/@([a-zA-Z0-9_\.\-]+)");
        xpath = xpath.Replace("\"", "'");
        // Find matches
        Match m = r.Match(xpath);
        XNode currentNode = elem;
        StringBuilder currentPath = new StringBuilder();
        while (m.Success)
        {
            String currentXPath = m.Groups[0].Value;    // "/configuration" or "/appSettings" or "/add"
            String elementName = m.Groups[1].Value;     // "configuration" or "appSettings" or "add"
            String filterName = m.Groups[3].Value;      // "" or "key"
            String filterValue = m.Groups[4].Value;     // "" or "name"
            String attributeName = m.Groups[5].Value;   // "" or "value"
            StringBuilder builder = currentPath.Append(currentXPath);
            String relativePath = builder.ToString();
            XNode newNode = (XNode)elem.XPathSelectElement(relativePath);
            if (newNode == null)
            {
                if (!string.IsNullOrEmpty(attributeName))
                {
                    ((XElement)currentNode).Attribute(attributeName).Value = "";
                    newNode = (XNode)elem.XPathEvaluate(relativePath);
                }
                else if (!string.IsNullOrEmpty(elementName))
                {
                    XElement newElem = new XElement(elementName);
                    if (!string.IsNullOrEmpty(filterName))
                    {
                        newElem.Add(new XAttribute(filterName, filterValue));
                    }
                    ((XElement)currentNode).Add(newElem);
                    newNode = newElem;
                }
                else
                {
                    throw new FormatException("The given xPath is not supported " + relativePath);
                }
            }
            currentNode = newNode;
            m = m.NextMatch();
        }
        // Assure that the node is found or created
        if (elem.XPathEvaluate(xpath) == null)
        {
            throw new FormatException("The given xPath cannot be created " + xpath);
        }
        return currentNode;
    }
