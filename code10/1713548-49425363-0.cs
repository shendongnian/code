    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    using System.Data.OleDb;
    namespace ConsoleApplication31
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
     
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement article = doc.Root;
                XNamespace ns = article.GetDefaultNamespace();
                XElement fundingSource = article.Descendants(ns + "funding-source").Where(x => (string)x.Element(ns + "institution-wrap") == "Ford Foundation").FirstOrDefault();
                XElement institutionWrap = fundingSource.Element(ns + "institution-wrap");
                institutionWrap.Add(new XElement("institution-id", new object[] { 
                    new XAttribute("institution-id-type","fundref"),
                    "10.13039/100000010"
            }));
            }
     
        }
    }
