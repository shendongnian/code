    public void CreatePoints(string xml)
    {
        XPathDocument doc = new XPathDocument(XmlReader.Create(new StringReader(xml)));
        var xPathNodeIterator = doc.CreateNavigator().Select("/Data/Points/Point");
        foreach (XPathNavigator node in xPathNodeIterator)
        {
            var x = node.SelectSingleNode("@X").ValueAsInt;
            var y = node.SelectSingleNode("@Y").ValueAsInt;
    
            new Point(x, y);
        }
    }
