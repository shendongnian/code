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
                XDocument doc = XDocument.Load(FILENAME);
                XElement relationships = doc.Descendants("Relationships").FirstOrDefault();
                XNamespace ns = "http://mws.amazonservices.com/schema/Products/2011-10-01";
                string marketplaceId = (string)relationships.Descendants(ns + "MarketplaceId").FirstOrDefault();
            }
        }
    }
