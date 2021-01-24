    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication67
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                RemoveRecursive(root);
            }
            static void RemoveRecursive(XElement element)
            {
                var groups = element.Elements()
                    .GroupBy(x => new { tagname = x.Name.LocalName, itemname = (string)x.Attribute("name") })
                    .Select(x => x.Select(y => new { element = y, index = (string)y.Attribute("href") == "" ? 0 : 1 })).ToList();
                foreach(var group in groups)
                {
                    var orderGroup = group.OrderByDescending(x => x.index).ToList();
                    for (int i = orderGroup.Count() - 1; i > 0; i--)
                    {
                        orderGroup[i].element.Remove();
                    }
                }
                foreach(XElement child in element.Elements())
                {
                    if (child.HasElements) RemoveRecursive(child);
                }
            }
        }
    }
