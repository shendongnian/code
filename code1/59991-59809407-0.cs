    XDocument xdoc = XDocument.Load(sourceFileName);
    XPathNavigator navi = xdoc.Root.CreateNavigator();
    XmlNamespaceManager xmlNSM = new XmlNamespaceManager(navi.NameTable);
    //Get all the namespaces from navigator
    IDictionary<string, string> dict = navi.GetNamespacesInScope(XmlNamespaceScope.All);
    //Copy them into Manager
    foreach (KeyValuePair<string, string> pair in dict)
    {
        xmlNSM.AddNamespace(pair.Key, pair.Value);
    }
