    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlTextReader.Create(FILENAME);
                List<Xml> xmls = new List<Xml>();
                while (!reader.EOF)
                {
                    if (reader.Name != "xml")
                    {
                        reader.ReadToFollowing("xml");
                    }
                    if (!reader.EOF)
                    {
                        XElement xml = (XElement)XElement.ReadFrom(reader);
                        Xml item = new Xml() { item1 = (string)xml.Element("item1"), item2 = (string)xml.Element("item2")};
                        xmls.Add(item);
                    }
                }
            }
        }
        public class Xml
        {
            public string item1 { get; set; }
            public string item2 { get; set; }
        }
    }
