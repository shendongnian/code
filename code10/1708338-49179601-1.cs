    using System;
    using System.Collections;
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
                new Widget(FILENAME);
            }
        }
        public class Widget
        {
            public static Widget root = new Widget();
            public String type { get; set; }
            public String name { get; set; }
            public String labelCation { get; set; }
            public String text { get; set; }
            public String dbpath { get; set; }
            public List<Widget> subsection { get; set; }
            public Widget() { }
            public Widget(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement root = doc.Root;
                RecursiveParse(root, Widget.root);
            }
            public static void RecursiveParse(XElement xParent, Widget textParent)
            {
                foreach (XElement child in xParent.Elements())
                {
                    string elementName = child.Name.LocalName;
                    switch (elementName)
                    {
                        case "label" :
                            textParent.name = (string)child.Attribute("name");
                            textParent.labelCation = (string)child.Attribute("text");
                            textParent.dbpath = (string)child.Attribute("dbpath");
                            break;
                        case "section" :
                            if (textParent.subsection == null) textParent.subsection = new List<Widget>();
                            Widget childSection = new Widget();
                            textParent.subsection.Add(childSection);
                            RecursiveParse(child, childSection);
                            break;
                        default :
                            textParent.text = (string)child.Attribute("text");
                            textParent.labelCation = elementName;
                            break;
                    }
                }
            }
        }
    }
