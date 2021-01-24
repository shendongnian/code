    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XElement doc = XElement.Load(FILENAME);
                Product product = doc.Descendants("Product").Select(x => new Product() {
                    refCode = (string)x.Element("RefCode"),
                    siteCode = x.Elements("SiteCode").Select(y => (int)y).ToArray(),
                    status = (string)x.Element("Status")
                }).FirstOrDefault();
            }
        }
        public class Product
        {
            public string refCode { get; set; }
            public int[] siteCode { get; set; }
            public string status { get; set; }
        }
        
    }
