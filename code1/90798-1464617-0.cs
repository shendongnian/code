    using System;
    using System.Xml;
    namespace ReadXml1
    {
        class Class1
        {
            static void Main(string[] args)
            {
                // Create an isntance of XmlTextReader and call Read method to read the file
                XmlTextReader textReader = new XmlTextReader("C:\\books.xml");
                textReader.Read();
                // If the node has value
                while (textReader.Read())
                {
                    // Move to fist element
                    textReader.MoveToElement();
                    Console.WriteLine("XmlTextReader Properties Test");
                    Console.WriteLine("===================");
                    // Read this element's properties and display them on console
                    Console.WriteLine("Name:" + textReader.Name);
                    Console.WriteLine("Base URI:" + textReader.BaseURI);
                    Console.WriteLine("Local Name:" + textReader.LocalName);
                    Console.WriteLine("Attribute Count:" + textReader.AttributeCount.ToString());
                    Console.WriteLine("Depth:" + textReader.Depth.ToString());
                    Console.WriteLine("Line Number:" + textReader.LineNumber.ToString());
                    Console.WriteLine("Node Type:" + textReader.NodeType.ToString());
                    Console.WriteLine("Attribute Count:" + textReader.Value.ToString());
                }
            }
        }
    }
