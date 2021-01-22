    T RemoveAllNamespaces<T>(T node) where T : XObject
    {
        return node.Accept(
            new ChangeNamespaceVisitor(new RemoveNamespaceMappingManager())
        ) as T;
    }
    
    public class RemoveNamespaceMappingManager : INamespaceMappingManager
    {
        public INamespaceMapping GetMapping(XNamespace fromNs)
        {
            return new RemoveNamespaceMapping();
        }
        
        private class RemoveNamespaceMapping : INamespaceMapping
        {
            public XName ChangeNamespace(XName name)
            {
                return name.LocalName;
            }
            
            public XObject ChangeNamespaceDeclaration(XAttribute node)
            {
                return null;
            }
        }
    }
