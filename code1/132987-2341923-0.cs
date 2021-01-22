    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    
    namespace XmlIndent
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml = "<doc><object><first>Joe</first><last>Smith</last></object></doc>";
                var xd = new XmlDocument();
                xd.LoadXml(xml);
                Console.WriteLine(FormatXml(xd));
                Console.ReadKey();
            }
    
    
            static string FormatXml(XmlDocument doc)
            {
                var sb = new StringBuilder();
                var sw = new StringWriter(sb);
                XmlTextWriter xtw = null;
                using(xtw = new XmlTextWriter(sw) { Formatting = Formatting.Indented })
                {
                    doc.WriteTo(xtw);
                }
                return sb.ToString();
            }
        }
    }
