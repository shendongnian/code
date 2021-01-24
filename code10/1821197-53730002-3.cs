    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication91
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement documents = doc.Descendants("Documents").FirstOrDefault();
                XElement groupElement = new XElement("SomeGroupElement2", new object[] {
                    new XAttribute("XMLElementA","ABCD"),
                    new XAttribute("XMLElementB","123"),
                    new XAttribute("XMLElementC","XYZ"),
                    new XAttribute("XMLElementD","1")
                });
                documents.ReplaceWith(groupElement);
                XElement grouping = new XElement("Grouping");
                groupElement.Add(grouping);
                for(int i = 1; i <= 3; i++)
                {
                    XElement newXElement = new XElement("XMLelement" + i.ToString(), "Value" + i.ToString());
                    grouping.Add(newXElement);
                }
            }
        }
    }
