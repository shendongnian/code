    using System;
    using System.Globalization;
    using System.IO;
    using System.Xml.XPath;
    using System.Xml.Xsl;
    public class MyExtensionObject
    {
        private static string[] formats = new string[] { /* ... */ };
        public string dateDiff(string x, string y)
        {
            CultureInfo culture = new CultureInfo("en-US");
            TimeSpan delta = DateTime.ParseExact(y, formats, culture, DateTimeStyles.None)
                - DateTime.ParseExact(x, formats, culture, DateTimeStyles.None);
            return delta.ToString();
        }
    }
    class Program
    {
        static void Main()
        {
            XsltArgumentList args = new XsltArgumentList();
            args.AddExtensionObject("my-namespace", new MyExtensionObject());
            XslTransform xslt = new XslTransform();
            xslt.Load("foo.xslt");
            using(TextWriter output = File.CreateText("out.txt")) {
                XPathDocument input = new XPathDocument("foo.xml");
                xslt.Transform(input, args, output);
            }
            
        }
    }
