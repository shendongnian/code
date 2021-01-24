    using System;
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
                string lStrXMLRequest = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(lStrXMLRequest);
                XElement ord = doc.Descendants().Where(x => x.Name.LocalName == "Org").FirstOrDefault();
                ord.SetValue("abc");
            }
        }
    }
