    private void ParseXml(
        TextWriter resultStream,
        TextReader sourceStream)
    {
        XmlDocument doc = new XmlDocument();
        doc.PreserveWhitespace = true;
        doc.Load(sourceStream);
        ParseXmlNodes(doc.DocumentElement);
        using (XmlWriter xw = XmlWriter.Create(resultStream))
        {
            doc.WriteTo(xw);
        }
    }
    /// <summary>
    /// Parse a single XML node and its children.
    /// </summary>
    /// <param name="node"></param>
    private void ParseXmlNodes(XmlNode node)
    {
        if (node.NodeType == XmlNodeType.Element)
        {
            //
            //  Replace tokens in XML attribute values
            //
            foreach (XmlAttribute a in node.Attributes)
            {
                a.Value = DoYourStringReplace(a.Value);
            }
        }
        else if (node.NodeType == XmlNodeType.Text)
        {
            //
            //  Replace tokens in the XML Element value
            //
            node.Value = DoYourStringReplace(node.Value);
        }
        //
        //  Do the same thing for all children
        //
        foreach (XmlNode child in node.ChildNodes)
        {
            ParseXmlNodes(child);
        }
    }
