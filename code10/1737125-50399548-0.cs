    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication45
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var groups = doc.Descendants("version")
                    .GroupBy(x => (int)x.Attribute("number"))
                    .ToList();
                foreach (var group in groups)
                {
                    foreach (XElement row in group)
                    {
                        string location = (string)row.Element("location").Attribute("path");
                        int fields = (int)row.Element("numberOfFields");
                        string[] fieldTypes = row.Descendants("type").Select(x => (string)x).ToArray();
                        Console.WriteLine("Version : '{0}', Location : '{1}', Number Of Fields : '{2}', Columns : '{3}'", group.Key.ToString(), location, fields.ToString(), string.Join(",", fieldTypes));
                    }
                }
                Console.ReadLine();
     
            }
        }
    }
