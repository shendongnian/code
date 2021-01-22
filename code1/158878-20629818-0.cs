    public static class XmlDocumentExtensions
    {
        public static void IterateThroughAllNodes(
            this XmlDocument doc, 
            Action<XmlElement> elementVisitor)
        {
            if (doc != null && elementVisitor != null)
            {
                foreach (XmlElement node in doc.ChildNodes)
                {
                    doIterateNode(node, elementVisitor);
                }
            }
        }
        private static void doIterateNode(
            XmlElement node, 
            Action<XmlElement> elementVisitor)
        {
            elementVisitor(node);
            foreach (XmlElement childNode in node.ChildNodes)
            {
                doIterateNode(childNode, elementVisitor);
            }
        }
    }
