    public static XDocument CreateElement(XDocument document, string xpath)
    {
        if (string.IsNullOrEmpty(xpath))
            throw new InvalidOperationException("Xpath must not be empty");
        var xNodes = Regex.Matches(xpath, @"\/[^\/]+").Cast<Match>().Select(it => it.Value).ToList();
        if (!xNodes.Any())
            throw new InvalidOperationException("Invalid xPath");
        var parent = document.Root;
        var currentNodeXPath = "";
        foreach (var xNode in xNodes)
        {
            currentNodeXPath += xNode;
            var nodeName = Regex.Match(xNode, @"(?<=\/)[^\[]+").Value;
            var existingNode = parent.XPathSelectElement(currentNodeXPath);
            if (existingNode != null)
            {
                parent = existingNode;
                continue;
            }
            var attributeNames =
              Regex.Matches(xNode, @"(?<=@)([^=]+)\=([^]]+)")
                    .Cast<Match>()
                    .Select(it =>
                    {
                        var groups = it.Groups.Cast<Group>().ToList();
                        return new { AttributeName = groups[1].Value, AttributeValue = groups[2].Value };
                    });
            parent.Add(new XElement(nodeName, attributeNames.Select(it => new XAttribute(it.AttributeName, it.AttributeValue)).ToArray()));
            parent = parent.Descendants().Last();
        }
        return document;
    }
