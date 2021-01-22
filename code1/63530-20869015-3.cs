    public class ChangeNamespaceVisitor : XObjectVisitor
    {
        private INamespaceMappingManager manager;
        public ChangeNamespaceVisitor(INamespaceMappingManager manager)
        {
            Validation.CheckArgumentNull(manager, "manager");
            
            this.manager = manager;
        }
        
        protected INamespaceMappingManager Manager { get { return manager; } }
        
        private XName ChangeNamespace(XName name)
        {
            var mapping = Manager.GetMapping(name.Namespace);
            return mapping.ChangeNamespace(name);
        }
        
        private XObject ChangeNamespaceDeclaration(XAttribute node)
        {
            var mapping = Manager.GetMapping(node.Value);
            return mapping.ChangeNamespaceDeclaration(node);
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
    // and all the gory implementation details
    public class NamespaceMappingManager : INamespaceMappingManager
    {
        private Dictionary<XNamespace, INamespaceMapping> namespaces = new Dictionary<XNamespace, INamespaceMapping>();
        
        public NamespaceMappingManager Add(XNamespace fromNs, XNamespace toNs, string toPrefix = null)
        {
            var item = new NamespaceMapping(fromNs, toNs, toPrefix);
            namespaces.Add(item.FromNs, item);
            return this;
        }
    
        public INamespaceMapping GetMapping(XNamespace fromNs)
        {
            INamespaceMapping mapping;
            if (!namespaces.TryGetValue(fromNs, out mapping))
                mapping = new NullMapping();
            return mapping;
        }
        
        private class NullMapping : INamespaceMapping
        {
            public XName ChangeNamespace(XName name)
            {
                return name;
            }
            
            public XObject ChangeNamespaceDeclaration(XAttribute node)
            {
                return node.Update(node.Name, node.Value);
            }
        }
        
        private class NamespaceMapping : INamespaceMapping
        {
            private XNamespace fromNs;
            private XNamespace toNs;
            private string toPrefix;
            public NamespaceMapping(XNamespace fromNs, XNamespace toNs, string toPrefix = null)
            {
                this.fromNs = fromNs ?? "";
                this.toNs = toNs ?? "";
                this.toPrefix = toPrefix;
            }
            
            public XNamespace FromNs { get { return fromNs; } }
            public XNamespace ToNs { get { return toNs; } }
            public string ToPrefix { get { return toPrefix; } }
            
            public XName ChangeNamespace(XName name)
            {
                return name.Namespace == fromNs
                    ? toNs + name.LocalName
                    : name;
            }
            
            public XObject ChangeNamespaceDeclaration(XAttribute node)
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
        }
    }
    
    public interface INamespaceMappingManager
    {
        INamespaceMapping GetMapping(XNamespace fromNs);
    }
    
    public interface INamespaceMapping
    {
        XName ChangeNamespace(XName name);
        XObject ChangeNamespaceDeclaration(XAttribute node);
    }
