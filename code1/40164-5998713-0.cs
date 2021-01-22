    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace CsFoo
    {
      public class Foo
      {
        [XmlElement("BarStandard", typeof(BarStandardSerializable))]
        [XmlElement("BarCustom", typeof(BarCustomSerializable))]
        public Bar BarProperty { get; set; }
      }
    
      public abstract class Bar
      { }
    
      public class BarStandardSerializable : Bar
      { }
    
      public class BarCustomSerializable : Bar, IXmlSerializable
      {
        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader xr) { }
        public void WriteXml(XmlWriter xw) { }
      }
    
      class CsFoo
      {
        static void Main()
        {
            StringWriter sw = new StringWriter();
            Foo f1 = new Foo() { BarProperty = new BarCustomSerializable() };
            XmlSerializer xs = new XmlSerializer(typeof(Foo));
            
            xs.Serialize(sw, f1);
            StringReader sr= new StringReader(sw.ToString());
            Foo f2 = (Foo)xs.Deserialize(sr);
        }
      }
    }
