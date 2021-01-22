    using System;
    using System.Xml.Serialization;
     public class Person
    {
        static void Main()
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attribs = new XmlAttributes();
            attribs.XmlIgnore = false;
            attribs.XmlElements.Add(new XmlElementAttribute("personName"));
            overrides.Add(typeof(Person), "Name", attribs);
    
            XmlSerializer ser = new XmlSerializer(typeof(Person), overrides);
            Person person = new Person();
            person.Name = "Marc";
            ser.Serialize(Console.Out, person);
        }
        private string name;
        [XmlElement("name")]
        [XmlIgnore]
        public string Name { get { return name; } set { name = value; } }
    }
