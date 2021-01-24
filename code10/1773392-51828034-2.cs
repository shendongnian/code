    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME_1 = @"c:\temp\test1.xml";
            const string FILENAME_2 = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc1 = XDocument.Load(FILENAME_1);
                XDocument doc2 = XDocument.Load(FILENAME_2);
                var results = (from d1 in doc1.Descendants("Person")
                               join d2 in doc2.Descendants("Empeloyeur") on (int)d1.Element("ID") equals (int)d2.Element("ID")
                               select new { person = d1, empelour = d2 })
                              .ToList();
                DataTable dt = new DataTable("person");
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name",typeof(string));
                dt.Columns.Add("Age", typeof(int));
                dt.Columns.Add("Job", typeof(string));
                foreach(var result in results)
                {
                    dt.Rows.Add(new object[] { (int)result.person.Element("ID"), (string)result.person.Element("name"), (int)result.person.Element("Age"), (string)result.empelour.Element("Job") }); 
                }
            }
        }
    }
