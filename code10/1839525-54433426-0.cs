    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(QCalls));
                QCalls qCalls = (QCalls)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("QCalls")]
        public class QCalls
        {
            [XmlElement("Q")]
            public List<Q> q { get; set; }
        }
        [XmlRoot("Q")]
        public class Q
        {
            [XmlElement("phone")]
            public Phone phone { get; set; }
        }
        [XmlRoot("phone")]
        public class Phone
        {
            [XmlAttribute("id")]
            public int id { get; set; }
            [XmlAttribute("n")]
            public string queue { get; set; }
            [XmlAttribute("cw")]
            public int cw { get; set; }
            [XmlAttribute("cwt")]
            public int cwt { get; set; }
        }
    }
