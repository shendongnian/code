    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication58
    {
        class Program
        {
            const string FILENAME = @"C:\TEMP\TEST.XML";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<KeyValuePair<string, string>> names = doc.Descendants("Employee")
                    .Select(x => new KeyValuePair<string, string>((string)x.Element("FirstName"), (string)x.Element("LastName")))
                    .ToList();
            }
        }
    }
