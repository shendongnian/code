    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string data = File.ReadAllText("D:\\xml.txt");
                string appender = "<root>" + data + "</root>";
                XmlSerializer xmldata = new XmlSerializer(typeof(Root));
                byte[] byteArray = Encoding.ASCII.GetBytes(data);
                MemoryStream stream = new MemoryStream(byteArray);
    
                object datafromXml = xmldata.Deserialize(stream);
    
            }
        }
    
            [XmlRoot(ElementName = "Miu")]
            public class Miu
            {
                [XmlElement(ElementName = "PremiseID")]
                public string PremiseID { get; set; }
                [XmlElement(ElementName = "PremiseAccount")]
                public string PremiseAccount { get; set; }
                [XmlElement(ElementName = "PremiseLatitude")]
                public string PremiseLatitude { get; set; }
                [XmlElement(ElementName = "PremiseLongitude")]
                public string PremiseLongitude { get; set; }
                [XmlAttribute(AttributeName = "MiuId")]
                public string MiuId { get; set; }
            }
    
            [XmlRoot(ElementName = "CollectorDate")]
            public class CollectorDate
            {
                [XmlElement(ElementName = "CollectorLatitude")]
                public string CollectorLatitude { get; set; }
                [XmlElement(ElementName = "CollectorLongitude")]
                public string CollectorLongitude { get; set; }
                [XmlElement(ElementName = "Miu")]
                public List<Miu> Miu { get; set; }
                [XmlAttribute(AttributeName = "Date")]
                public string Date { get; set; }
                [XmlAttribute(AttributeName = "CollectorId")]
                public string CollectorId { get; set; }
            }
    
            [XmlRoot(ElementName = "CollectorHeardMIUs")]
            public class CollectorHeardMIUs
            {
                [XmlElement(ElementName = "CollectorDate")]
                public List<CollectorDate> CollectorDate { get; set; }
            }
    
            [XmlRoot(ElementName = "root")]
            public class Root
            {
                [XmlElement(ElementName = "CollectorHeardMIUs")]
                public List<CollectorHeardMIUs> CollectorHeardMIUs { get; set; }
            }
    
        }
