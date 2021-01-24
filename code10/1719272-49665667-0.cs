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
            const string FILENAME = @"\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement user = doc.Root;
                XNamespace ns = user.GetDefaultNamespace();
                string UserGUID = (string)user.Element(ns + "UserGUID");
            }
        }
    }
