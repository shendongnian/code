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
                List<Policy> policies = doc.Descendants("Policy").Select(item => new Policy() {
                    PolNumber = (string)item.Element("PolNumber"),
                    FirstName = (string)item.Element("FirstName"),
                    LastName = (string)item.Element("LastName"),
                    BirthDate = (string)item.Element("BirthDate"),
                    MailType = (string)item.Element("MailType")
                }).ToList();
            }
        }
        public class Policy
        {
            public string PolNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string BirthDate { get; set; }
            public string MailType { get; set; }
        }
    }
