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
                XElement sites = doc.Descendants("Sites").FirstOrDefault();
                var groups = doc.Descendants("SiteServer").GroupBy(x => (int)x.Element("ID")).ToList();
                XElement newSites = new XElement("Sites");
                foreach(var group in groups)
                {
                    XElement newSiteServers = new XElement("SiteServers", group);
                    newSites.Add(newSiteServers);
                }
                sites.ReplaceWith(newSites);
            }
        }
    }
