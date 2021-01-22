    public static IEnumerable<XmlNode> StreamNodes(
        string path,
        string[] tagNames) {            
        var doc = new XmlDocument();            
        using (XmlReader xr = XmlReader.Create(path)) {
            xr.MoveToContent();
            while (true) {
                if (xr.NodeType == XmlNodeType.Element &&
                    tagNames.Contains(xr.Name)) {
                    var node = doc.ReadNode(xr);
                    yield return node;
                } else {
                    if (!xr.Read()) {
                        break;
                    }
                }
            }
            xr.Close();
        }                        
    }
    // Used like this:
    foreach (var el in StreamNodes("orders.xml", new string[]{"order"})) {
        ....
    }
