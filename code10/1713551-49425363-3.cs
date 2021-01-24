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
            const string DATABASE = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement article = doc.Root;
                XNamespace ns = article.GetDefaultNamespace();
                XDocument docDatabase = XDocument.Load(DATABASE);
                XElement rdf = docDatabase.Root;
                XNamespace nsSkosxl = rdf.GetNamespaceOfPrefix("skosxl");
                XNamespace nsRdf = rdf.GetNamespaceOfPrefix("rdf");
                List<XElement> prefLabels = rdf.Descendants(nsSkosxl + "prefLabel").ToList();
                Dictionary<string, List<string>> dictLabels = prefLabels.GroupBy(x => (string)x.Descendants(nsSkosxl + "literalForm").FirstOrDefault(), y => (string)y.Element(nsSkosxl + "Label").Attribute(nsRdf + "about"))
                    .ToDictionary(x => x.Key, y => y.ToList());
                List<XElement> fundingSources = article.Descendants(ns + "funding-source").ToList();
                foreach (XElement fundingSource in fundingSources)
                {
                    XElement institutionWrap = fundingSource.Element(ns + "institution-wrap");
                    string institution = (string)fundingSource;
                    if (dictLabels.ContainsKey(institution))
                    {
                        institutionWrap.Add(new XElement("institution-id", new object[] { 
                           new XAttribute("institution-id-type","fundref"),
                           dictLabels[institution]
                        }));
                    }
                    else
                    {
                        Console.WriteLine("Dictionary doesn't contain : '{0}'", institution);
                    }
                }
                Console.ReadLine();
            }
        }
    }
