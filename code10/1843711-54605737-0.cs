    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication100
    {
        class Program
        {
            const string XML_FILENAME = @"c:\temp\test.xml";
            const string CSV_FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                PropStat.ParseXML(XML_FILENAME);
                PropStat.CreateCSV(CSV_FILENAME);
            }
     
        }
        public class PropStat
        {
            public static List<PropStat> propStats = new List<PropStat>();
            public string href { get; set; }
            public string handle { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string username { get; set; }
            public string email { get; set; }
            public Boolean?  isactive { get; set; }
            public string domain { get; set; }
            public string status { get; set; }
            public static void ParseXML(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                foreach (XElement response in doc.Descendants(ns + "response"))
                {
                    string href = (string)response.Element(ns + "href");
                    foreach(XElement propstat in response.Descendants(ns + "propstat"))
                    {
                        PropStat newPropStat = new PropStat();
                        propStats.Add(newPropStat);
                        newPropStat.href = href;
                        XElement dsref = propstat.Descendants(ns + "dsref").FirstOrDefault();
                        if (dsref != null)
                        {
                            newPropStat.handle = (string)dsref.Attribute("handle");
                        }
                        newPropStat.firstname = (string)propstat.Descendants(ns + "firstname").FirstOrDefault();
                        newPropStat.lastname = (string)propstat.Descendants(ns + "lastname").FirstOrDefault();
                        newPropStat.username = (string)propstat.Descendants(ns + "username").FirstOrDefault();
                        newPropStat.email = (string)propstat.Descendants(ns + "email").FirstOrDefault();
                        newPropStat.isactive = (string)propstat.Descendants(ns + "isactive").FirstOrDefault() == "0" ? false : true;
                        newPropStat.domain = (string)propstat.Descendants(ns + "domain").FirstOrDefault();
                        newPropStat.status = (string)propstat.Descendants(ns + "status").FirstOrDefault();
                    }
                    
                }
            }
            public static void CreateCSV(string filename)
            {
                StreamWriter writer = new StreamWriter(filename);
                string header = string.Join(",",
                    "href",
                    "handle",
                    "firstname",
                    "lastname",
                    "username",
                    "email",
                    "isactive",
                    "domain",
                    "status");
                writer.WriteLine(header);
                foreach (PropStat propstat in propStats)
                {
                    string data = string.Join(",",
                        propstat.href,
                        propstat.handle,
                        propstat.firstname,
                        propstat.lastname,
                        propstat.username,
                        propstat.email,
                        propstat.isactive,
                        propstat.domain,
                        propstat.status);
                    writer.WriteLine(data);
                }
                writer.Flush();
                writer.Close();
            }
        }
      
        
    }
