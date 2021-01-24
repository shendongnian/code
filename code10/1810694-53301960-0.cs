    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Runtime;
    namespace ConsoleApplication83
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                string change = doc.Descendants("add").Where(x => x.Attribute("initializeData") != null).Select(x => (string)x.Attribute("initializeData")).FirstOrDefault();
            }
        
        }
    }
