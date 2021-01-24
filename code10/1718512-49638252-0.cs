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
            static void Main(string[] args)
            {
                string version = "1.21";
                string dateprodstart =   DateTime.Now.ToString("yyyyMMdd");
                string heureprodstart=  DateTime.Now.ToString("hh:mm:ss");
                string dateprodend =   DateTime.Now.ToString("yyyyMMdd");
                string heureprodend =  DateTime.Now.ToString("hh:mm:ss");
                Dictionary<string,List<string>> dict = new Dictionary<string,List<string>>() {
                    { "Item", new List<string>() {
                                "filename, test5; destination,0; test1, EVA00; test2, ko",
                                "filename, test5; destination,0; test1, EVA00; test2, ko",
                                "filename, test5; destination,0; test1, EVA00; test2, ko",
                                "filename, test5; destination,0; test1, EVA00; test2, ko"
                              }
                    }
                };
                string ident = "<?xml version=\"1.0\" encoding=\"utf- 8\"?><ListItems></ListItems>";
                XDocument doc = XDocument.Parse(ident);
                XElement listItems = doc.Root;
                listItems.Add(new XAttribute[] {
                    new XAttribute("dateprodstart",dateprodstart),
                    new XAttribute("heureprodstart",heureprodstart ),
                    new XAttribute("dateprodend",dateprodend),
                    new XAttribute("heureprodend",heureprodend),
                    new XAttribute("version",version)
                });
                foreach (string item in dict["Item"].AsEnumerable())
                {
                    XElement xItem = new XElement("item");
                    listItems.Add(xItem);
                    string[] elements = item.Split(new char[] { ';' });
                    foreach (string element in elements)
                    {
                        string[] csv = element.Split(new char[] { ',' });
                        XElement newElement = new XElement(csv[0].Trim(), csv[1].Trim());
                        xItem.Add(newElement);
                    }
                }
            }
        }
    }
