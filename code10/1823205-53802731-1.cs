    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                RequestModel model = new RequestModel() {
                    ix = 123,
                    content = new Content() {
                        Name = "NAMEVALUE",
                        Visits = 456,
                        dateRequested = "2018-12-16"
                    }
                };
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(RequestModel));
                serializer.Serialize(writer, model);
            }
        }
        [XmlRoot(ElementName = "request")]
        public class RequestModel
        {
            [XmlElement("ix")]
            public int ix { get; set; }
            [XmlElement("content")]
            public Content content { get; set; }
        }
        [XmlRoot(ElementName = "content")]
        public class Content
        {
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("visits")]
            public int? Visits { get; set; }
            private DateTime Date { get; set; }
            [XmlElement("dateRequested")]
            public string dateRequested
            {
                get { return Date.ToString("yyyy-MM-dd"); }
                set { Date = DateTime.ParseExact(value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); }
            }
        }
    }
