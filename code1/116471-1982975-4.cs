    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    static class Program
    {
        static void Main()
        {
            MyType obj = new MyType { Name = "Fred" };
            var ser = new XmlSerializer(obj.GetType());
            ser.Serialize(Console.Out, obj);
        }
    }
    public class MyType : IXmlSerializable
    {
        public MyType()
        {
            FixedProperties = new MyTypeFixedProperties();
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public MyTypeFixedProperties FixedProperties { get; set; }
        [XmlIgnore]
        public string Name
        {
            get { return FixedProperties.Name; }
            set { FixedProperties.Name = value; }
        }
    
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
    
        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            throw new System.NotImplementedException();
        }
    
        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("DynamicProperties");
            writer.WriteElementString("Foo", "Bar");
            writer.WriteEndElement();
            fixedPropsSerializer.Serialize(writer, FixedProperties);
        }
        static readonly XmlSerializer fixedPropsSerializer
            = new XmlSerializer(typeof(MyTypeFixedProperties));
    
    }
    [XmlRoot("FixedProperties")]
    public class MyTypeFixedProperties
    {
        public string Name { get; set; }
    }
