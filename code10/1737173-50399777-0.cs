    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication45
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Type", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement planet in doc.Descendants("Planet"))
                {
                    dt.Rows.Add(new object[] {
                        (string)planet.Attribute("Name"),
                        (string)planet.Attribute("Type")
                    });
                }
            }
        }
    }
