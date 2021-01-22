    using System;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    
    class Test
    {
        public static void Main(string[] args)
        {
            using(WebClient webclient = new WebClient())
            {
                webclient.Proxy = null;
                string locationXml = webclient.DownloadString
                    ("http://maps.google.com/maps/api/geocode/xml?address=1600"
                     + "+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=false");
                XElement root = XElement.Parse(locationXml);
                
                XElement result = root.Element("result");
                Console.WriteLine(result.Elements("address_component")
                                        .Where(x => (string) x.Element("type") ==
                                               "administrative_area_level_1")
                                        .Select(x => x.Element("short_name").Value)
                                        .First());
                Console.WriteLine(result.Elements("address_component")
                                        .Where(x => (string) x.Element("type") ==
                                               "administrative_area_level_2")
                                        .Select(x => x.Element("long_name").Value)
                                        .First());
            }
        }
    }
