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
                new Textmemo(FILENAME);
            }
        }
        public class Textmemo
        {
            public static Textmemo root = new Textmemo();
            public String type { get; set; }
            public String name { get; set; }
            public String labelCation { get; set; }
            public String text { get; set; }
            public String dbpath { get; set; }
            public List<Textmemo> subsection { get; set; }
            public Textmemo() { }
            public Textmemo(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement root = doc.Root;
                RecursiveParse(root, Textmemo.root);
            }
            public static void RecursiveParse(XElement xParent, Textmemo textParent )
            {
                XElement label = xParent.Element("label");
                if (label != null)
                {
                    textParent.name = (string)label.Attribute("name");
                    textParent.labelCation = (string)label.Attribute("text");
                    textParent.dbpath = (string)label.Attribute("dbpath");
                }
                XElement textMemo = xParent.Element("textmemo");
                if (textMemo != null)
                {
                    textParent.text = (string)textMemo.Attribute("text");
                }
                foreach (XElement section in xParent.Elements("section"))
                {
                    if (textParent.subsection == null) textParent.subsection = new List<Textmemo>();
                    Textmemo child = new Textmemo();
                    textParent.subsection.Add(child);
                    RecursiveParse(section, child);
                }
            }
        }
    }
