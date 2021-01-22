        public static class XmlExtenders
    {
        public static XmlNode SelectFirstNode(this XmlNode node, string xPath)
        {
            const string prefix = "pfx";
            XmlNamespaceManager nsmgr = GetNsmgr(node, prefix);
            string prefixedPath = GetPrefixedPath(xPath, prefix);
            return node.SelectSingleNode(prefixedPath, nsmgr);
        }
        public static XmlNodeList SelectAllNodes(this XmlNode node, string xPath)
        {
            const string prefix = "pfx";
            XmlNamespaceManager nsmgr = GetNsmgr(node, prefix);
            string prefixedPath = GetPrefixedPath(xPath, prefix);
            return node.SelectNodes(prefixedPath, nsmgr);
        }
        public static XmlNamespaceManager GetNsmgr(XmlNode node, string prefix)
        {
            string namespaceUri;
            XmlNameTable nameTable;
            if (node is XmlDocument)
            {
                nameTable = ((XmlDocument) node).NameTable;
                namespaceUri = ((XmlDocument) node).DocumentElement.NamespaceURI;
            }
            else
            {
                nameTable = node.OwnerDocument.NameTable;
                namespaceUri = node.NamespaceURI;
            }
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(nameTable);
            nsmgr.AddNamespace(prefix, namespaceUri);
            return nsmgr;
        }
        public static string GetPrefixedPath(string xPath, string prefix)
        {
            char[] validLeadCharacters = "@/".ToCharArray();
            char[] quoteChars = "\'\"".ToCharArray();
            List<string> pathParts = xPath.Split("/".ToCharArray()).ToList();
            string result = string.Join("/",
                                        pathParts.Select(
                                            x =>
                                            (string.IsNullOrEmpty(x) ||
                                             x.IndexOfAny(validLeadCharacters) == 0 ||
                                             (x.IndexOf(':') > 0 &&
                                              (x.IndexOfAny(quoteChars) < 0 || x.IndexOfAny(quoteChars) > x.IndexOf(':'))))
                                                ? x
                                                : prefix + ":" + x).ToArray());
            return result;
        }
    }
