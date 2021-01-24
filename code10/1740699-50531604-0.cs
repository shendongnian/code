    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication45
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
     
            static void Main(string[] args)
            {
                new Node(FILENAME);
            }
      
        }
        public class Node
        {
            public static Node root = null;
            public string name { get; set; }
            public List<Node> children { get; set; }
            public Dictionary<string, string> dict { get; set; }
            public Node() { }
            public Node(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement xRoot = doc.Root;
                root = new Node();
                RecursiveParse(xRoot, root);
            }
            public void RecursiveParse(XElement xParent, Node node)
            {
                node.name = xParent.Name.LocalName;
                foreach (XAttribute attribute in xParent.Attributes())
                {
                    if (node.dict == null) node.dict = new Dictionary<string, string>();
                    node.dict.Add(attribute.Name.LocalName, (string)attribute);
                }
                foreach (XElement element in xParent.Elements())
                {
                    if (element.HasElements)
                    {
                        Node child = new Node();
                        if (node.children == null) node.children = new List<Node>();
                        node.children.Add(child);
                        RecursiveParse(element, child);
                    }
                    else
                    {
                        if (node.dict == null) node.dict = new Dictionary<string, string>();
                        node.dict.Add(element.Name.LocalName, (string)element);
                    }
                }
            }
        }
    }
