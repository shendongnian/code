    public class DynamicExtension
    {
        XPathNavigator _context;
        IXmlNamespaceResolver _namespaceResolver;
        public DynamicExtension(XPathNavigator p_context, IXmlNamespaceResolver p_namespaceResolver)
        {
            _context = p_context;
            _namespaceResolver= p_namespaceResolver;
        }
        public object evaluate(string p_expression)
        {
            return _context.Evaluate(p_expression, _namespaceResolver);
        }
    }
