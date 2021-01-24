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
                XElement resprocessing = doc.Descendants("resprocessing").FirstOrDefault();
                string header = "<?xml version=\"1.0\" encoding=\"utf-8\"?><resprocessing></resprocessing>";
                XDocument newDoc = XDocument.Parse(header);
                XElement newResprocessing = newDoc.Root;
                newResprocessing.ReplaceWith(resprocessing);
            }
        }
    }
