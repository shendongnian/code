static private XmlNode makeXPath(XmlDocument doc, string xpath)
{
    return makeXPath(doc, doc as XmlNode, xpath);
}
static private XmlNode makeXPath(XmlDocument doc, XmlNode parent, string xpath)
{
    // grab the next node name in the xpath; or return parent if empty
    string[] partsOfXPath = xpath.Trim('/').Split('/');
    string nextNodeInXPath = partsOfXPath.First();
    if (string.IsNullOrEmpty(nextNodeInXPath))
        return parent;
    // get or create the node from the name
    XmlNode node = parent.SelectSingleNode(nextNodeInXPath);
    if (node == null)
        node = parent.AppendChild(doc.CreateElement(nextNodeInXPath));
    // rejoin the remainder of the array as an xpath expression and recurse
    string rest = String.Join("/", partsOfXPath.Skip(1).ToArray());
    return makeXPath(doc, node, rest);
}
static void Main(string[] args)
{
    XmlDocument doc = new XmlDocument();
    doc.LoadXml("&lt;feed /&gt;");
    makeXPath(doc, "/feed/entry/data");
    XmlElement contentElement = (XmlElement)makeXPath(doc, "/feed/entry/content");
    contentElement.SetAttribute("source", "");
    Console.WriteLine(doc.OuterXml);
}
