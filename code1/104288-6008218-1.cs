    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    class Program
    {
        public static XmlDocument GetXmlDocument(OpenXmlPart part)
        {
            XmlDocument xmlDoc = new XmlDocument();
            using (Stream partStream = part.GetStream())
            using (XmlReader partXmlReader = XmlReader.Create(partStream))
                xmlDoc.Load(partXmlReader);
            return xmlDoc;
        }
        static void Main(string[] args)
        {
            using (WordprocessingDocument doc =
                WordprocessingDocument.Open("Test.docx", false))
            {
                XmlDocument xmlDoc = GetXmlDocument(doc.MainDocumentPart);
                string wordNamespace =
                    "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
                XmlNamespaceManager nsmgr =
                    new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("w", wordNamespace);
                XmlElement bookmarkStart = (XmlElement)xmlDoc.SelectSingleNode("descendant::w:bookmarkStart[@w:id='0']", nsmgr);
                XmlNodeList nodesFollowing = bookmarkStart.SelectNodes("following::*", nsmgr);
                var nodesBetween = nodesFollowing
                    .Cast<XmlNode>()
                    .TakeWhile(n =>
                        {
                            if (n.Name != "w:bookmarkEnd")
                                return true;
                            if (n.Attributes.Cast<XmlAttribute>().Any(a => a.Name == "w:id" && a.Value == "0"))
                                return false;
                            return true;
                        });
                foreach (XmlElement item in nodesBetween)
                {
                    Console.WriteLine(item.Name);
                    if (item.Name == "w:bookmarkStart" || item.Name == "w:bookmarkEnd")
                        foreach (XmlAttribute att in item.Attributes)
                            Console.WriteLine("{0}:{1}", att.Name, att.Value);
                }
            }
        }
    }
