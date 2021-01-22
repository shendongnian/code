    using System;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Xml.Xsl;
    class Html2TextExample
    {
        public static string Html2Text(XDocument source)
        {
            var writer = new StringWriter();
            Html2Text(source, writer);
            return writer.ToString();
        }
        public static void Html2Text(XDocument source, TextWriter output)
        {
            Transformer.Transform(source.CreateReader(), null, output);
        }
        public static XslCompiledTransform _transformer;
        public static XslCompiledTransform Transformer
        {
            get
            {
                if (_transformer == null)
                {
                    _transformer = new XslCompiledTransform();
                    var xsl = XDocument.Parse(@"<?xml version='1.0'?><xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" exclude-result-prefixes=""xsl""><xsl:output method=""html"" indent=""yes"" version=""4.0"" omit-xml-declaration=""yes"" encoding=""UTF-8"" /><xsl:template match=""/""><xsl:value-of select=""."" /></xsl:template></xsl:stylesheet>");
                    _transformer.Load(xsl.CreateNavigator());
                }
                return _transformer;
            }
        }
        static void Main(string[] args)
        {
            var html = XDocument.Parse("<html><body><div>Hello world!</div></body></html>");
            var text = Html2Text(html);
            Console.WriteLine(text);
        }
    }
