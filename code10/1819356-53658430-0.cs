    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication90
    {
        class Program
        {
            static void Main(string[] args)
            {
                string userID = "JohnSmith";
                string[] ids  = {"123456789","123456789","123456789","123456789","123456789","123456789"};
                string header = "http://production.shippingapis.com/ShippingAPI.dll?API=TrackV2&XML=";
                string xmlHeader = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><TrackRequest></TrackRequest>";
                XDocument doc = XDocument.Parse(xmlHeader);
                XElement trackRequest = doc.Root;
                trackRequest.Add(new XAttribute("USERID", userID));
                foreach(string id in ids)
                {
                    XElement trackID = new XElement("TrackID", new XAttribute("ID",id));
                    trackRequest.Add(trackID);
                }
                string output = header + doc.ToString();
            }
        }
    }
