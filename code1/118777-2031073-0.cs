    using System;
    using System.ComponentModel;
    using System.Xml;
    using System.Xml.Serialization;
    public class Bar { }
    public class Foo
    {
        public Bar Bar { get; set; }
        
        [XmlIgnore]
        public string XmlJunkAsString { get; set; }
    
        [XmlElement("XmlJunkAsString"), Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public XmlElement XmlJunkAsStringSerialized
        {
            get
            {
                string xml = XmlJunkAsString;
                if (string.IsNullOrEmpty(xml)) return null;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                return doc.DocumentElement;
            }
            set
            {
                XmlJunkAsString = value == null ? null : value.OuterXml;
            }
        }
    }
    static class Program {
        static void Main()
        {
            var obj = new Foo
            {
                Bar = new Bar(),
                XmlJunkAsString = "<xml><that/><will/><not/><be/><parsed/></xml>"
            };
            var ser = new XmlSerializer(obj.GetType());
            ser.Serialize(Console.Out, obj);
        }
    }
