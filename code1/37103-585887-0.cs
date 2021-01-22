    XmlNamespaceManager manager = new XmlNamespaceManager(myXmlDocument.NameTable);
                                manager.AddNamespace("o", "namespaceforOuterElement");
                                manager.AddNamespace("i", "namespaceforInnerElement");
    string xpath = @"/o:outerelement/i:innerelement"
    // For single node value selection
    XPathExpression xPathExpression = navigator.Compile(xpath );
    string reportID = myXmlDocument.SelectSingleNode(xPathExpression.Expression, manager).InnerText;
    // For multiple node selection
    XmlNodeList myNodeList= myXmlDocument.SelectNodes(xpath, manager);
