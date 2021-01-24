    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Node.ParseChildren(FILENAME);
            }
        }
        public class Node
        {
            public static Node root { get; set; }
            public static XmlReader reader;
            public static Dictionary<string, int> dict = new Dictionary<string, int>();
            string name { get; set; }
            List<Node> children { get; set; }
            public static void ParseChildren(string filename)
            {
                reader = XmlReader.Create(filename);
                reader.MoveToContent();
                root = new Node();
                root.name = reader.Name;
                reader.ReadStartElement();
                ParseChildrenRecursive(root,root.name);
            }
     
            public static void ParseChildrenRecursive(Node node, string path)
            {
                while (!reader.EOF)
                {
                    if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        reader.ReadEndElement();
                        break;
                    }
                    if (reader.IsStartElement())
                    {
                        if (node.children == null) node.children = new List<Node>();
                        Node child = new Node();
                        node.children.Add(child);
                        child.name = reader.LocalName;
                        string newPath = path + " > " + child.name;
                        if(dict.ContainsKey(newPath))
                        {
                            dict[newPath] += 1;
                        }
                        else
                        {
                            dict.Add(newPath, 1);
                        }
                        reader.ReadStartElement();
                        ParseChildrenRecursive(child, newPath);
                    }
                    reader.Read();
                }
            }
        }
    }
