    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq ;
    namespace ConsoleApplication91
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var usa = doc.Descendants().Where(x => x.Name.LocalName == "AddressData").Where(x => x.Elements().Any(y => (y.Name.LocalName == "Country") && ((string)y == "US"))).FirstOrDefault();
            }
        }
    }
