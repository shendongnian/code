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
                List<XElement> productNodes = doc.Descendants("PRODUCT").ToList();
                List<Product> product = productNodes.Select(x => new Product() {
                    Mode = (string)x.Attribute("mode"),
                    No = (string)x.Element("SUPPLIER_PID"),
                    DescriptionShort = (string)x.Descendants("DESCRIPTION_SHORT").FirstOrDefault(),
                    DescriptionLong = (string)x.Descendants("DESCRIPTION_LONG").FirstOrDefault(),
                    //EANCode = XmlUtils.nodeAsString(productNode, "./PRODUCT_DETAILS/EAN"),
                    //Stock = XmlUtils.nodeAsInt(productNode, "./PRODUCT_DETAILS/STOCK"),
                    OrderUnit = (string)x.Descendants("ORDER_UNIT").FirstOrDefault(),
                    ContentUnit = (string)x.Descendants("CONTENT_UNIT").FirstOrDefault(),
                    Currency =  (string)x.Descendants("PRICE_CURRENCY").FirstOrDefault(),
                    mime = x.Elements("MIME").Select(y => new Mime() {
                        Source = (string)y.Element("MIME_SOURCE"),
                        Type = (string)y.Element("MIME_TYPE"),
                        Purpose = (string)y.Element("MIME_PURPOSE")
                    }).ToList()
                }).ToList();
            }
        }
        public class Product
        {
            public string Mode  { get; set;}
            public string No  { get; set;}
            public string DescriptionShort  { get; set;}
            public string DescriptionLong  { get; set;}
            public string EANCode  { get; set;}
            public string OrderUnit  { get; set;}
            public string ContentUnit  { get; set;}
            public string Currency  { get; set;}
            public string Vat  { get; set;} 
            public List<Mime> mime { get; set;}
        }
        public class Mime
        {
            public string Source { get; set; }
            public string Type { get; set;}
            public string Purpose { get; set;}
     
        }
    }
