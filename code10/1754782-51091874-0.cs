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
                string input = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                               "<p:Msg xmlns:tns=\"http://xyx.com\" xmlns:p=\"http://www.xyx.com/location/921.xsd\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                                  "<Header>" +
                                     "<Type>P:B2</Type>" +
                                     "<UserID>MARKISCOOL</UserID>" +
                                     "<MsgID>4213</MsgID>" +
                                  "</Header>" +
                                  "<Data>" +
                                     "<StatusRecord>" +
                                        "<TimestampUTCCurrent hex=\"40B18261\" intermediate=\"1085375073\" uom=\"\">2016-01-20T06:05:55Z</TimestampUTCCurrent>" +
                                        "<FileType hex=\"00002765\" intermediate=\"10003\" uom=\"\">10003</FileType>" +
                                     "</StatusRecord>" +
                                  "</Data>" +
                               "</p:Msg>";
                XDocument doc = XDocument.Parse(input);
                XElement msg = doc.Root;
                XNamespace ns = msg.GetDefaultNamespace();
                XNamespace pNs = msg.GetNamespaceOfPrefix("p");
                Info info = doc.Elements(pNs + "Msg").Select(x => new Info()
                {
                    Type = (string)x.Descendants(ns + "Type").FirstOrDefault(),
                    UserID = (string)x.Descendants(ns + "UserID").FirstOrDefault(),
                    MessageId = (int)x.Descendants(ns + "MsgID").FirstOrDefault(),
                    TimestampUTCCurrent = (string)x.Descendants(ns + "TimestampUTCCurrent").FirstOrDefault(),
                    FileType = (int)x.Descendants(ns + "FileType").FirstOrDefault()
                }).FirstOrDefault();
            }
        }
        public class Info
        {
            public string Type { get; set; }
            public string UserID { get; set; }
            public int MessageId { get; set; }
            public string TimestampUTCCurrent { get; set; }
            public int FileType { get; set; }
        }
    }
