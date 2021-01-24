    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            private const String XmlPath = @"..\..\TestCases\";
            static void Main(string[] args)
            {
                XElement xRoot = new XElement("Root");
                foreach (string file in Directory.GetFiles(XmlPath))
                {
                    XDocument doc = XDocument.Load(file);
                    XElement root = doc.Root;
                    xRoot.Add(root);
                }
            }
        }
