    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication87
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";   
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                StringReader stream = new StringReader(xml);
                XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                Envelope deserialized = (Envelope)serializer.Deserialize(stream);
            }
        }
        [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement("Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body body { get; set; }
        }
        [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Body
        {
            [XmlElement("loginResponse", Namespace = "http://tasks.ws.com/")]
            public LoginResponse loginResponse { get; set; }
        }
        [XmlRoot("loginResponse", Namespace = "http://tasks.ws.com/")]
        public class LoginResponse
        {
            [XmlElement("LoginResult", Namespace = "")]
            public LoginResult loginResult { get; set; }
        }
        [XmlRoot("LoginResult", Namespace = "")]
        public class LoginResult
        {
            [XmlElement("uid")]
            public string Uid { get; set; }
            [XmlElement("mapServerList")]
            public MapServerList mapServerList { get; set; }
        }
        [XmlRoot("SERVER", Namespace = "")]
        public class SERVER
        {
            public string name { get; set; }
            public string URL { get; set; }
            public int maxZoom { set; get; }
        }
        [XmlRoot("mapServerList", Namespace = "")]
        public class MapServerList
        {
            [XmlElement("SERVER")]
            public List<SERVER> mapServerList { get; set; }
        }
     
    }
