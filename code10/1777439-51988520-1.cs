    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        public class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            private static void Main()
            {
                StreamReader reader = new StreamReader(FILENAME);
                reader.ReadLine(); //skip the unicode encoding in the ident
                XDocument doc = XDocument.Load(reader);
                XElement arrayOfPerson = doc.Descendants("ArrayOfPerson").FirstOrDefault();
                arrayOfPerson.Add(new XElement("Person"), new object[] {
                    new XElement("Id", 0),
                    new XElement("Name", "Person 0"),
                    new XElement("Birthday", DateTime.Now.ToLongDateString()),
                });
            }
        }
    }
