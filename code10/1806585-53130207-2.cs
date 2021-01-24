    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace TP3
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument xmldoc = XDocument.Load(FILENAME);
                XElement bannedIPs = xmldoc.Descendants("BannedIPs").FirstOrDefault();
                string IP = "NewArrayItemHere";
                XElement newXElement = new XElement("BannedIP", IP);
                bannedIPs.Add(newXElement);
                xmldoc.Save(FILENAME);
            }
        }
    }
