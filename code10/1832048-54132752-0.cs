    sing System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Net;
    using System.Net.Sockets;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication94
    {
        class Program
        {
            static void Main(string[] args)
            {
                var url = "https://tel.search.ch/examples/api-response.xml";
                var doc = new XDocument();
                HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    doc = XDocument.Load(resp.GetResponseStream());
                }
                XNamespace ns = doc.Root.GetDefaultNamespace();
                XNamespace telNs = doc.Root.GetNamespaceOfPrefix("tel");
                // Format Data
                var query = from el in doc.Descendants(ns + "entry")
                            select new
                            {
                                Position = (string)el.Element(telNs + "pos"),
                                Id = (string)el.Element(telNs + "id"),
                                Type = (string)el.Element(telNs + "type"),
                                Name = (string)el.Element(telNs + "name"),
                                Firstname = (string)el.Element(telNs + "firstname"),
                                Occupation = (string)el.Element(telNs + "occupation"),
                                Street = (string)el.Element(telNs + "street"),
                                StreetNo = (string)el.Element(telNs + "streetno"),
                                Zip = (string)el.Element(telNs + "zip"),
                                City = (string)el.Element(telNs + "city"),
                                Canton = (string)el.Element(telNs + "canton"),
                                Phone = (string)el.Element(telNs + "phone")
                            };
                var list = query.ToList();
            }
        }
     
    }
