    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace ConsoleApplicationCSharp
    {
      public class ObjectToSerialize : IXmlSerializable
      {
        public string Value1;
        public string Value2;
        public string Value3;   
        public string ValueToSerialize;
        public string Value4;
        public string Value5;
 
        public ObjectToSerialize() { }
    
        public void WriteXml(System.Xml.XmlWriter writer)
        {
          writer.WriteElementString("Val", ValueToSerialize);
        }
    
        public void ReadXml(System.Xml.XmlReader reader) 
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Event")
            {
                ValueToSerialize = reader["Val"];
                reader.Read();
            }        
        }
        public XmlSchema GetSchema() { return (null); }
        public static void Main(string[] args)
        {
          ObjectToSerialize t = new ObjectToSerialize();
          t. ValueToSerialize= "Hello";
          System.Xml.Serialization.XmlSerializer x = new XmlSerializer(typeof(ObjectToSerialize));
          x.Serialize(Console.Out, t);
          return;
        }
      }
    }
