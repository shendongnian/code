    using System;
    using System.Xml;
    
    class Program {
        static void Main(string[] args) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.NewLineChars = "\n";
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(@"c:\temp\test.xml", settings);
            XmlDocument doc = new XmlDocument();
            doc.InnerXml = "<root><element>value</element></root>";
            doc.WriteTo(writer);
            writer.Close();
        }
    }
