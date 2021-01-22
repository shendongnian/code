    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    [XmlRoot("instance")]
    public class AnimalInstance {
        [XmlElement("dog")]
        public Dog Dog { get; set; }
    }
    public class Dog {
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<Item> Items = new List<Item>();
    }
    public class Item {
        [XmlElement("label")]
        public string Label { get; set; }
    }
    class Program {
        static void Main(params string[] args) {
            string xml = @"<instance>
    <dog>
        <items>
            <item>
                <label>Spaniel</label>
            </item>
        </items>
    </dog>
    </instance>";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AnimalInstance));
            AnimalInstance instance = (AnimalInstance)xmlSerializer.Deserialize(new StringReader(xml));
        }
    }
