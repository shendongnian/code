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
                string ident = "<?xml version=\"1.0\" encoding=\"utf-8\"?><resources></resources>";
                XDocument doc = XDocument.Parse(ident);
                XElement resources = doc.Root;
                resources.Add(new XElement("string", new object[] {
                    new XAttribute("name","app_name"),
                    "Automation Test"
                }));
                resources.Add(new XElement("string", new object[] {
                    new XAttribute("name","current_data_state_incoming_call"),
                    "مكالمات قادمة"
                }));
            }
        }
    }
