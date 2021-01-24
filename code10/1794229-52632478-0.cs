    string fileName = @"C:\file.xml";
    using (XmlTextReader reader = new XmlTextReader(fileName)) //using System.Xml
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Whitespace || reader.NodeType == XmlNodeType.EndElement) continue;
                    Console.WriteLine("\n------------------------------------------------------------------------------");
                    string message = $"Position: {reader.LineNumber},{reader.LinePosition}\tNode Type: {reader.NodeType.ToString()}\tDepth: {reader.Depth}\n";
                    if (reader.Name.Trim() != "") message += $"Name: {reader.Name}\t";
                    if (reader.Value.Trim() != "") message += $"Value: {reader.Value}\t";
                    Console.WriteLine(message);
                    // Read() method doesn't get into attribute nodes, so check them manually then get them by MoveToFirstElementAttribute() and MoveToNextAttribute() methods
                    if (reader.HasAttributes)
                    {
                        Console.WriteLine($"\nHas {reader.AttributeCount} Attribute(s):\n");
                        reader.MoveToFirstAttribute();
                        Console.WriteLine($"Attribute Name: {reader.Name}\tValue: {reader.Value}");
                        while (reader.MoveToNextAttribute())
                        {
                            Console.WriteLine($"Attribute Name: {reader.Name}\tValue: {reader.Value}");
                        }
                        reader.MoveToElement();
                    }
                }
            }
