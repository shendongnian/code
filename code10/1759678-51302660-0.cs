    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
     
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("Friend").Select(x => new {
                    fName = (string)x.Element("FName"),
                    lName = (string)x.Element("LName"),
                    age = (int)x.Element("Age"),
                    ids = x.Descendants("FriendId")
                       .GroupBy(y => (string)y.Attribute("IdType"), z => (string)z)
                       .ToDictionary(y => y.Key, z => z.FirstOrDefault())
                }).ToList();
     
     
     
            }
        }
     
     
    }
