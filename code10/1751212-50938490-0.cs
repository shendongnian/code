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
            static void Main(string[] args)
            {
                string header = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" +
                                "<my:Updated_By xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                                  " xmlns:pc=\"http://schemas.microsoft.com/office/infopath/2007/PartnerControls\"" +
                                  " xmlns:dms=\"http://schemas.microsoft.com/office/2009/documentManagement/types\"" +
                                  " xmlns:my=\"http://schemas.microsoft.com/office/infopath/2003/myXSD/2007-09-02T01:11:44\">" +
                                "</my:Updated_By>";
                XDocument doc = XDocument.Parse(header);
                XElement root = doc.Root;
                XNamespace pcNs = root.GetNamespaceOfPrefix("pc");
                string name = "John";
                string id = "123";
                string type = "person";
                root.Add(new XElement(pcNs + "Person",
                    new XElement(pcNs + "DisplayName", name),
                    new XElement(pcNs + "AccountId", id),
                    new XElement(pcNs + "AccountType", type)
                    ));
                doc.Save("filename");
            }
        }
    }
