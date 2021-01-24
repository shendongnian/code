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
                XElement job_command = doc.Descendants().Where(x => x.Name.LocalName == "job_command").FirstOrDefault();
                XNamespace pjobNs = job_command.GetNamespaceOfPrefix("pjob");
                var results = job_command.Descendants(pjobNs +  "var").Select(x => new {
                    name = (string)x.Attribute("name"),
                    value = (string)x
                }).ToList();
            }
        }
    }
