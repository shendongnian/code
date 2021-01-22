    class Util
    {
        public static string
        LazyWrapper (string html, int limit) {
            var d = new XmlDocument();
            d.InnerXml = html;
            var e = d.FirstChild;
            Truncate(e, limit);
            return d.InnerXml;
        }
        public static void
        Truncate(XmlNode node, int limit) {
            TruncateHelper(node, limit, 0);
        }
        public static int
        TruncateHelper(XmlNode node, int limit, int found) {
            switch (node.NodeType) {
            case XmlNodeType.Element:
                var child = node.FirstChild;
                while (child != null) {
                    found = TruncateHelper(child, limit, found);
                    if (found >= limit) {
                        // remove all FUTURE elements
                        while (child.NextSibling != null) {
                            child.ParentNode.RemoveChild(child.NextSibling);
                        }
                    }
                    child = child.NextSibling;
                }
                return found;
            case XmlNodeType.Text:
                var remaining = limit - found;
                if (node.Value.Length < remaining) {
                    // still room for more (at least one more letter)
                    return found + node.Value.Length;
                }
                node.Value = node.Value.Substring(0, remaining);
                return limit;
            default:
                return found;
            }
        }
        
    }
