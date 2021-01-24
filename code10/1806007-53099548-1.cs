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
            public static XmlReader reader;
            public static Dictionary<string, int> dict = new Dictionary<string, int>();
            //string name { get; set; }
            //List<Node> children { get; set; }
            public static void ParseChildren(string filename)
            {
                reader = XmlReader.Create(filename);
                reader.MoveToContent();
                string name = "";
                reader.ReadStartElement();
                ParseChildrenRecursive(name);
            }
     
            public static void ParseChildrenRecursive(string path)
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
                        string childName = reader.LocalName;
                        string newPath = path + " > " + childName;
                        if(dict.ContainsKey(newPath))
                        {
                            dict[newPath] += 1;
                        }
                        else
                        {
                            dict.Add(newPath, 1);
                        }
                        reader.ReadStartElement();
                        ParseChildrenRecursive(newPath);
                    }
                    reader.Read();
                }
            }
        }
    }
