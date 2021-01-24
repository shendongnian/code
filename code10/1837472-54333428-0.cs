    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication98
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(DigitalSales));
                DigitalSales digitalSales = (DigitalSales)serializer.Deserialize(reader);
                reader.Close();
                XmlWriter writer = XmlWriter.Create(FILENAME);
                serializer.Serialize(writer, digitalSales);
            }
        }
        [XmlRoot("digital-sales")]
        public class DigitalSales
        {
            [XmlElement("supervisor")]
            public Supervisor supervisor { get; set; }
        }
        [XmlRoot("supervisor")]
        public class Supervisor
        {
            [XmlAttribute("id")]
            public string Id { set; get; }
            [XmlElement("Name")]
            public string Name { set; get; }
            [XmlElement("Contract")]
            public int Contracts { set; get; }
            [XmlElement("Volume")]
            public long Volume { set; get; }
            [XmlElement("Average")]
            public int Average { set; get; }
        }
     
    }
