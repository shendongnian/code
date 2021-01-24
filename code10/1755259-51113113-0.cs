    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                int index = 0;
                foreach(XElement obj in doc.Descendants("Object"))
                {
                    obj.SetAttributeValue("type", "0x" + index++.ToString("x"));
                }
            }
        }
    }
