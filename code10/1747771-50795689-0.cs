    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication48
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var groups = (from d in doc.Descendants("d")
                                 join xdoc in doc.Descendants("document") on (string)d.Attribute("id") equals (string)xdoc.Attribute("DocumentID")
                                 select new List<XElement> { d, xdoc })
                                 .GroupBy(x => (string)x.FirstOrDefault().Attribute("id"))
                                 .Select(x => x.SelectMany(y => y).ToList())
                                 .ToList();
                List<Document> documents = new List<Document>();
                foreach (var group in groups)
                {
                    Document newDoc = new Document();
                    documents.Add(newDoc);
                    foreach (XElement element in group)
                    {
                        foreach (XAttribute attribute in element.Attributes())
                        {
                            switch (attribute.Name.LocalName.ToUpper())
                            {
                                case "ID" :
                                    newDoc.id = (string)attribute;
                                    break;
                                case "DOCUMENTID":
                                    newDoc.id = (string)attribute;
                                    break;
                                case "NAME":
                                    newDoc.name = (string)attribute;
                                    break;
                                case "N":
                                    newDoc.name = (string)attribute;
                                    break;
                                case "CDATE":
                                    newDoc.date = (DateTime)attribute;
                                    break;
                                case "CREATIONDATE":
                                    newDoc.date = (DateTime)attribute;
                                    break;
                                case "SIZE":
                                    newDoc.size = (long)attribute;
                                    break;
                                case "S":
                                    newDoc.size = (long)attribute;
                                    break;
                                default :
                                    break;
                            }
                        }
                    }
                }
            }
        }
        public class Document
        {
            public string id { get; set; }
            public string name {get; set; }
            public long size { get; set; }
            public DateTime date { get; set; }
        }
    }
