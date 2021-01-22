        private void appendToOut(XmlNode node, XmlNode parameter)
        {
            if (node.ParentNode != null && node.ParentNode.NodeType != XmlNodeType.Document)
            {
                appendToOut(node.ParentNode, node);
            }
            diffRoot.AppendChild(diffDoc.ImportNode(node, node==parameter));
        }
