    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new Device(FILENAME);
            }
        }
        public class Device
        {
            public string IpAdress { get; set; }
            public string Statut { get; set; }
            public string MacAdress { get; set; }
            public string Hostname { get; set; }
            public string Vendor { get; set; }
            public static List<Device> getDeviceData { get; set; }
            public Device() { }
            public Device(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                Device.getDeviceData = doc.Descendants("Object").Select(x => new Device()
                {
                    IpAdress = x.Elements("Property").Where(y => (string)y.Attribute("Name") == "IPv4Address").Select(z => (string)z).FirstOrDefault(),
                    Statut = x.Elements("Property").Where(y => (string)y.Attribute("Name") == "Status").Select(z => (string)z).FirstOrDefault(),
                    MacAdress = x.Elements("Property").Where(y => (string)y.Attribute("Name") == "MAC").Select(z => (string)z).FirstOrDefault(),
                    Hostname = x.Elements("Property").Where(y => (string)y.Attribute("Name") == "Hostname").Select(z => (string)z).FirstOrDefault(),
                    Vendor = x.Elements("Property").Where(y => (string)y.Attribute("Name") == "Vendor").Select(z => (string)z).FirstOrDefault()
                }).ToList();
            }
        }
    }
