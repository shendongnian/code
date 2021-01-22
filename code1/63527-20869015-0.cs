    public abstract class XObjectVisitor
    {
        public virtual XObject Visit(XObject node)
        {
            if (node != null)
                return node.Accept(this);
            return node;
        }
        
        public ReadOnlyCollection<XObject> Visit(IEnumerable<XObject> nodes)
        {
            return nodes.Select(node => Visit(node))
                .Where(node => node != null)
                .ToList()
                .AsReadOnly();
        }
        
        public T VisitAndConvert<T>(T node) where T : XObject
        {
            if (node != null)
                return Visit(node) as T;
            return node;
        }
        
        public ReadOnlyCollection<T> VisitAndConvert<T>(IEnumerable<T> nodes) where T : XObject
        {
            return nodes.Select(node => VisitAndConvert(node))
                .Where(node => node != null)
                .ToList()
                .AsReadOnly();
        }
        
        protected virtual XObject VisitAttribute(XAttribute node)
        {
            return node.Update(node.Name, node.Value);
        }
        
        protected virtual XObject VisitComment(XComment node)
        {
            return node.Update(node.Value);
        }
    
        protected virtual XObject VisitDocument(XDocument node)
        {
            return node.Update(
                node.Declaration,
                VisitAndConvert(node.Nodes())
            );
        }
    
        protected virtual XObject VisitElement(XElement node)
        {
            return node.Update(
                node.Name,
                VisitAndConvert(node.Attributes()),
                VisitAndConvert(node.Nodes())
            );
        }
        
        protected virtual XObject VisitDocumentType(XDocumentType node)
        {
            return node.Update(
                node.Name,
                node.PublicId,
                node.SystemId,
                node.InternalSubset
            );
        }
    
        protected virtual XObject VisitProcessingInstruction(XProcessingInstruction node)
        {
            return node.Update(
                node.Target,
                node.Data
            );
        }
    
        protected virtual XObject VisitText(XText node)
        {
            return node.Update(node.Value);
        }
    
        protected virtual XObject VisitCData(XCData node)
        {
            return node.Update(node.Value);
        }
        
        #region Implementation details
        internal InternalAccessor Accessor
        {
            get { return new InternalAccessor(this); }
        }
        
        internal class InternalAccessor
        {
            private XObjectVisitor visitor;
            internal InternalAccessor(XObjectVisitor visitor) { this.visitor = visitor; }
        
            internal XObject VisitAttribute(XAttribute node) { return visitor.VisitAttribute(node); }
            internal XObject VisitComment(XComment node) { return visitor.VisitComment(node); }
            internal XObject VisitDocument(XDocument node) { return visitor.VisitDocument(node); }
            internal XObject VisitElement(XElement node) { return visitor.VisitElement(node); }
            internal XObject VisitDocumentType(XDocumentType node) { return visitor.VisitDocumentType(node); }
            internal XObject VisitProcessingInstruction(XProcessingInstruction node) { return visitor.VisitProcessingInstruction(node); }
            internal XObject VisitText(XText node) { return visitor.VisitText(node); }
            internal XObject VisitCData(XCData node) { return visitor.VisitCData(node); }
        }
        #endregion
    }
    
    public static class XObjectVisitorExtensions
    {
        #region XObject.Accept "instance" method
        public static XObject Accept(this XObject node, XObjectVisitor visitor)
        {
            CheckNullReference(node);
            CheckArgumentNull(visitor, "visitor");
                
            // yay, easy dynamic dispatch
            Acceptor acceptor = new Acceptor(node as dynamic);
            return acceptor.Accept(visitor);
        }
        private class Acceptor
        {
            public Acceptor(XAttribute node) : this(v => v.Accessor.VisitAttribute(node)) { }
            public Acceptor(XComment node) : this(v => v.Accessor.VisitComment(node)) { }
            public Acceptor(XDocument node) : this(v => v.Accessor.VisitDocument(node)) { }
            public Acceptor(XElement node) : this(v => v.Accessor.VisitElement(node)) { }
            public Acceptor(XDocumentType node) : this(v => v.Accessor.VisitDocumentType(node)) { }
            public Acceptor(XProcessingInstruction node) : this(v => v.Accessor.VisitProcessingInstruction(node)) { }
            public Acceptor(XText node) : this(v => v.Accessor.VisitText(node)) { }
            public Acceptor(XCData node) : this(v => v.Accessor.VisitCData(node)) { }
        
            private Func<XObjectVisitor, XObject> accept;
            private Acceptor(Func<XObjectVisitor, XObject> accept) { this.accept = accept; }
            
            public XObject Accept(XObjectVisitor visitor) { return accept(visitor); }
        }
        #endregion
    
        #region XObject.Update "instance" method
        public static XObject Update(this XAttribute node, XName name, string value)
        {
            CheckNullReference(node);
            CheckArgumentNull(name, "name");
            CheckArgumentNull(value, "value");
        
            return new XAttribute(name, value);
        }
        public static XObject Update(this XComment node, string value = null)
        {
            CheckNullReference(node);
            
            return new XComment(value);
        }
        public static XObject Update(this XDocument node, XDeclaration declaration = null, params object[] content)
        {
            CheckNullReference(node);
            
            return new XDocument(declaration, content);
        }
        public static XObject Update(this XElement node, XName name, params object[] content)
        {
            CheckNullReference(node);
            CheckArgumentNull(name, "name");
            
            return new XElement(name, content);
        }
        public static XObject Update(this XDocumentType node, string name, string publicId = null, string systemId = null, string internalSubset = null)
        {
            CheckNullReference(node);
            CheckArgumentNull(name, "name");
        
            return new XDocumentType(name, publicId, systemId, internalSubset);
        }
        public static XObject Update(this XProcessingInstruction node, string target, string data)
        {
            CheckNullReference(node);
            CheckArgumentNull(target, "target");
            CheckArgumentNull(data, "data");
        
            return new XProcessingInstruction(target, data);
        }
        public static XObject Update(this XText node, string value = null)
        {
            CheckNullReference(node);
            
            return new XText(value);
        }
        public static XObject Update(this XCData node, string value = null)
        {
            CheckNullReference(node);
            
            return new XCData(value);
        }
        #endregion
        
        #region Validation
        private static void CheckNullReference<T>(T node) where T : XObject
        {
            if (node == null)
                throw new NullReferenceException();
        }
        
        private static void CheckArgumentNull<T>(T obj, string paramName) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(paramName);
        }
        #endregion
    }
