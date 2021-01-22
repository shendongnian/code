    using System.Linq;
    
    namespace System.Xml.Linq
    {
        public static class XElementTransformExtensions
        {
            public static XElement WithoutNamespaces(this XElement source)
            {
                return new XElement(source.Name.LocalName,
                    source.Attributes().Select(WithoutNamespaces),
                    source.Nodes().Select(WithoutNamespaces)
                );
            }
    
            public static XAttribute WithoutNamespaces(this XAttribute source)
            {
                return !source.IsNamespaceDeclaration
                    ? new XAttribute(source.Name.LocalName, source.Value)
                    : default(XAttribute);
            }
    
            public static XNode WithoutNamespaces(this XNode source)
            {
                return
                    source is XElement
                        ? WithoutNamespaces((XElement)source)
                        : source;
            }
        }
    }
