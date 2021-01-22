    using System;
    using System.Text;
    using System.Xml;
    
    public class Test
    {
        static void Main()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;        
            StringBuilder builder = new StringBuilder();
            
            using (XmlWriter writer = XmlWriter.Create(builder, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                writer.WriteStartElement("element");
                writer.WriteString("content");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            Console.WriteLine(builder);
        }
    }
