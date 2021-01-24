    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
     
                //use parse to take string returned from request
                XDocument doc = XDocument.Parse(xml);
                
                KeyValuePair<string, List<string>> results = doc.Descendants("CustAddr").Where(x => (string)x.Element("AddrCode") == "PRIMARY")
                    .Select(x => new KeyValuePair<string, List<string>>((string)x.Element("FullName"), x.Elements().Where(y => Regex.IsMatch(y.Name.LocalName, @"Addr\d")).Select(y => (string)y).ToList())).FirstOrDefault(); 
            }
        }
    }
