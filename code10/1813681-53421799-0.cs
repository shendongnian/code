    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                reader.ReadLine(); // skip the utf-16 in header that Net Library doesn't accept
                XDocument doc = XDocument.Load(reader);
                string soapHeader = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:csdb=\"http://site.de/csdb\">" +
                    "<soapenv:Header/>" +
                    "<soapenv:Body>" +
                    "</soapenv:Body>" +
                    "</soapenv:Envelope>";
                XElement soap = XElement.Parse(soapHeader);
                XNamespace nsCsdb = soap.GetNamespaceOfPrefix("csdb");
                XNamespace nsSoapenv = soap.GetNamespaceOfPrefix("soapenv");
                XElement body = soap.Descendants(nsSoapenv + "Body").FirstOrDefault();
                body.Add(doc.Root);
                foreach (XElement child in body.Descendants())
                {
                    child.Name = nsCsdb.GetName(child.Name.LocalName);
                    List<XAttribute> atList = child.Attributes().ToList();
                    child.Attributes().Remove();
                    foreach (XAttribute at in atList)
                        child.Add(new XAttribute(nsCsdb.GetName(at.Name.LocalName), at.Value));
                }
            }
        }
    }
