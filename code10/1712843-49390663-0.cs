    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication31
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement fl = doc.Descendants("FL").FirstOrDefault();
                int[] dlrNumbers = fl.Elements("DOBJ").Select(x => x.Elements("ATTR").Where(y => (string)y.Attribute("Id") == "DLRNUMBER").Select(y => (int)y.Attribute("Val"))).SelectMany(y => y).ToArray();
            }
        }
    }
