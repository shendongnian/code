    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication78
    {
        class Program
        {
           
            static void Main(string[] args)
            {
                string ident = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><note></note>";
                XDocument doc = XDocument.Parse(ident);
                XElement note = doc.Root;
                note.Add(new XElement("to", "Tove"),
                    new XElement("example", new object[] {
                        new XElement("from", new object[] {
                            "Jani", new XElement("heading", "Reminder")
                        }),
                        new XElement("body","Don't forget me this weekend!")
                    })
                );
            }
        }
    }
