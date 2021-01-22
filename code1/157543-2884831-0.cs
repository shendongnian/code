    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Xml.Xsl;
    
    static class Extensions
    {
        public static XElement Transform(
            this XElement source, string xslPath, XsltArgumentList arguments)
        {
            var xsl = new XslCompiledTransform();
            xsl.Load(xslPath);
    
            var result = new XDocument();
            xsl.Transform(source.CreateNavigator(),arguments,result.CreateWriter());
            return result.Root;
        }
    }
