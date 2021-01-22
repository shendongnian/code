    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace ConsoleApplicationCSharp
    {
      public class Root : IXmlSerializable
      {
        public string Name;
        public string XmlString;
        
        public Root() { }
        
        public void WriteXml(System.Xml.XmlWriter writer)
        {
          writer.WriteElementString("Name", Name);
          writer.WriteStartElement("XmlString");
          writer.WriteRaw(XmlString);
          writer.WriteFullEndElement();
        }
    
        public void ReadXml(System.Xml.XmlReader reader) { /* ... */ }
        public XmlSchema GetSchema() { return (null); }
        public static void Main(string[] args)
        {
          Root t = new Root
          {
            Name = "Test",
            XmlString = "<Foo>bar</Foo>"
          };
          System.Xml.Serialization.XmlSerializer x = new XmlSerializer(typeof(Root));
          x.Serialize(Console.Out, t);
          return;
        }
      }
    }
