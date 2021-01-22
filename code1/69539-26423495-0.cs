    private XmlNamespaceManager GetNameSpaceManager(XmlDocument xDoc)
        {
            XmlNamespaceManager nsm = new XmlNamespaceManager(xDoc.NameTable);
            XPathNavigator RootNode = xDoc.CreateNavigator();
            RootNode.MoveToFollowing(XPathNodeType.Element);
            IDictionary<string, string> NameSpaces = RootNode.GetNamespacesInScope(XmlNamespaceScope.All);
            foreach (KeyValuePair<string, string> kvp in NameSpaces)
            {
                nsm.AddNamespace(kvp.Key, kvp.Value);
            }
            return nsm;
        }
