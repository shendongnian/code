    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XNamespace ns = doc.Root.GetDefaultNamespace();
                string msgId = (string)doc.Descendants(ns + "MsgId").FirstOrDefault();
                DateTime creDtTm = (DateTime)doc.Descendants(ns + "CreDtTm").FirstOrDefault();
     
            }
     
        }
     
    }
