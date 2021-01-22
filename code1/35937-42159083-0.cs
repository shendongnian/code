    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace Mediatel.Framework
    {
        public static class XDocumentHelper
        {
            public static IEnumerable<XElement> DescendantElements(this XDocument xDocument, string nodeName)
            {
                return xDocument.Descendants().Where(p => p.Name.LocalName == nodeName);
            }
        }
    }
