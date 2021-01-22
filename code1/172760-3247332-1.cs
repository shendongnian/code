    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    
    class Test
    {
        static void Main(string[] args)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);
                xmlWriter.Formatting = System.Xml.Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Root");
                xmlWriter.WriteEndElement();
                xmlWriter.Flush();
                
                XmlDocument doc = new XmlDocument();
                stream.Position = 0;
                doc.Load(stream);
                doc.Save(Console.Out);
            }
        }
    }
