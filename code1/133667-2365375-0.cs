    [XmlRoot("MyClass")]
    public class MyClassXmlWriter
    {
       private static XmlSerializer Serializer = new XmlSerializer(typeof MyClassXmlWriter);
       public static void Write(MyClass source, Stream st)
       {
          Serializer.Serialize(new MyClassXmlWriter(source), st);
       }
       private MyClass Source;
       private MyClassXmlWriter(MyClass source)
       {
          Source = source;
       }
       [XmlElement("SomeElement")]
       public string SomeProperty { get { return Source.SomeProperty; } }
    }
