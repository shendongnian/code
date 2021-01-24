    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("transaction").Select(x => x.Attributes().Select(y => new KeyValuePair<string, string>(y.Name.LocalName, y.Value)).ToArray()).ToArray();
     
            }
        }
    }
