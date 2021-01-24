    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
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
