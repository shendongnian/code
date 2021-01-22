    using System.Xml; 
    using System.Xml.Linq;
    
    namespace www.dimaka.com
    { 
        internal static class LinqHelper 
        { 
            public static XmlDocument ToXmlDocument(this XDocument xDocument) 
            { 
                var xmlDocument = new XmlDocument(); 
                using (var reader = xDocument.CreateReader()) 
                { 
                    xmlDocument.Load(reader); 
                }
    
                var xDeclaration = xDocument.Declaration; 
                if (xDeclaration != null) 
                { 
                    var xmlDeclaration = xmlDocument.CreateXmlDeclaration( 
                        xDeclaration.Version, 
                        xDeclaration.Encoding, 
                        xDeclaration.Standalone);
    
                    xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.FirstChild); 
                }
    
                return xmlDocument; 
            } 
        } 
    }
