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
                List<XElement> fundingSources = article.Descendants(ns + "funding-source").ToList();
                foreach (XElement fundingSource in fundingSources)
                {
                    XElement institutionWrap = fundingSource.Element(ns + "institution-wrap");
                    string instituation = (string)fundingSource;
                    //get value from other xml
                    institutionWrap.Add(new XElement("institution-id", new object[] { 
                       new XAttribute("institution-id-type","fundref"),
                       "10.13039/100000010"
                    }));
                }
            }
     
        }
    }
