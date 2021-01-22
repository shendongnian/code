    using System;
    using System.Xml;
    
    class Test
    {
        static void Main()
        {
            using (XmlWriter writer = XmlWriter.Create(Console.Out))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                writer.WriteRaw("<element>&nbsp;</element>");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
