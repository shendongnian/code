    public static class XmlDocumentExtensions
    {
        public static void IterateThroughAllNodes(
            this XmlDocument doc, 
            Action<XmlNode> elementVisitor)
        {
            if (doc != null && elementVisitor != null)
            {
                foreach (XmlNode node in doc.ChildNodes)
                {
                    doIterateNode(node, elementVisitor);
                }
            }
        }
        private static void doIterateNode(
            XmlNode node, 
            Action<XmlNode> elementVisitor)
        {
            elementVisitor(node);
            foreach (XmlNode childNode in node.ChildNodes)
            {
                doIterateNode(childNode, elementVisitor);
            }
        }
    }
