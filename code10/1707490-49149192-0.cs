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
            const String FILENAME  = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                List<XElement> comClientConfigurations = doc.Descendants().Where(x => x.Name.LocalName == "ComClientConfiguration").ToList();
                XNamespace ns = comClientConfigurations[0].GetDefaultNamespace();
                XElement comClientConfiguration = comClientConfigurations.Where(x => (string)x.Element(ns + "ServerName") == "DA").FirstOrDefault();
                comClientConfiguration.SetElementValue(ns + "MaxReconnectWait", 12345);
            }
        }
    }
