    var xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(@"<node1 attrib1=""abc"">
                             <node1_1>
                                <node1_1_1 />
                             </node1_1>
                             <node1_2 />
                             <node1_3 />
                          </node1>
                          <node2 />
    ");
    RemoveEmptyNodes(xmlDocument );
    private static bool RemoveEmptyNodes(XmlNode node)
    {
        if (node.HasChildNodes)
        {
            for(int I = node.ChildNodes.Count-1;I >= 0;I--)
                if (RemoveEmptyNodes(node.ChildNodes[I]))
                    node.RemoveChild(node.ChildNodes[I]);
        }
        return 
            (node.Attributes == null || 
                node.Attributes.Count == 0) && 
            node.InnerText.Trim() == string.Empty;
    }
