    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                List<XElement> strings = doc.Descendants("string").ToList();
                foreach (XElement xelement in strings)
                {
                    xelement.ReplaceWith(new XElement((string)xelement));
                }
            }
        }
    }
