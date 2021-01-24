    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = File.ReadAllText("D://check.xml");//your xml code is in file name check.xml
                var streamdata = new MemoryStream(Encoding.UTF8.GetBytes(data ?? ""));
                Stream st = streamdata;
                Root ro = new Root();
                XmlSerializer xml = new XmlSerializer(typeof(Root));
                ro=(Root)xml.Deserialize(st);
    
            }
        }
        [XmlRoot(ElementName = "root")]
        public class Root
        {
            [XmlElement(ElementName = "record")]
            public List<Record> records { get; set; }
        }
    
        public class Record
        {
            [XmlElement(ElementName = "ID")]
            public string ID { get; set; }
            [XmlElement(ElementName = "NAME")]
            public string Name { get; set; }
        }
    }
