    using System;
    using System.ComponentModel;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    public class Person
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlIgnore]
        public XElement Hobbies { get; set; }
    
        [XmlElement("Hobbies")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public XmlElement HobbiesSerialized
        {
            get
            {
                XElement hobbies = Hobbies;
                if(hobbies == null) return null;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(hobbies.ToString());
                return doc.DocumentElement;
            }
            set
            {
                Hobbies = value == null ? null
                    : XElement.Parse(value.OuterXml);
            }
        }
        [XmlElement("HomeAddress")]
        public Address HomeAddress { get; set; }
    }
    
    public class Address { }
    
    static class Progmam
    {
        static void Main()
        {
            var p = new Person { Hobbies = new XElement("xml", new XAttribute("hi","there")) };
            var ser = new XmlSerializer(p.GetType());
            ser.Serialize(Console.Out, p);
        }
    }
