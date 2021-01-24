    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication58
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement root = new XElement("root");
                XElement body = new XElement("body");
                root.Add(body);
                for (int id = 1; id <= 10; id++)
                {
                    XElement newSec = new XElement("sec",
                        new XAttribute("id", "sec" + id.ToString()),
                        XElement.Parse("<!--Parent also can contain no sub element or also can contain a free text--><p></p>"),
                        new XElement("p", "some free text")
                        );
                    body.Add(newSec);
                    XElement nodes = new XElement("p");
                    newSec.Add(nodes);
                    for (int childCount = 1; childCount <= 10; childCount++)
                    {
                        XElement newChild = new XElement("childNods", new XAttribute("id", "node" + childCount.ToString()),
                            "Child Text"
                         );
                        nodes.Add(newChild);
                    }
                }
     
            }
     
        }
    }
