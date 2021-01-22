    public class ChangeNamespaceVisitor : XObjectVisitor
    {
        private XNamespace fromNs;
        private XNamespace toNs;
        private string toPrefix;
        public ChangeNamespaceVisitor(XNamespace fromNs, XNamespace toNs, string toPrefix = null)
        {
            this.fromNs = fromNs ?? "";
            this.toNs = toNs ?? "";
            this.toPrefix = toPrefix;
        }
        
        private XName ChangeNamespace(XName name)
        {
            return name.Namespace == fromNs
                ? toNs + name.LocalName
                : name;
        }
        
        private XObject ChangeNamespaceDeclaration(XAttribute node)
        {
            if (node.Value == fromNs.NamespaceName)
            {
                if (toNs == XNamespace.None)
                    return null;
                var xmlns = !String.IsNullOrWhiteSpace(toPrefix)
                    ? (XNamespace.Xmlns + toPrefix)
                    : node.Name;
                return node.Update(xmlns, toNs.NamespaceName);
            }
            return node.Update(node.Name, node.Value);
        }
        
        protected override XObject VisitAttribute(XAttribute node)
        {
            if (node.IsNamespaceDeclaration)
                return ChangeNamespaceDeclaration(node);
            return node.Update(ChangeNamespace(node.Name), node.Value);
        }
        
        protected override XObject VisitElement(XElement node)
        {
            return node.Update(
                ChangeNamespace(node.Name),
                VisitAndConvert(node.Attributes()),
                VisitAndConvert(node.Nodes())
            );
        }
    }
