    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        public class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            private static void Main()
            {
                XDocument doc = XDocument .Load(FILENAME);
                DataTable dt = new DataTable();
                dt.Columns.Add("Field1", typeof(string));
                dt.Columns.Add("Field2", typeof(string));
                dt.Columns.Add("Field3", typeof(string));
                dt.Columns.Add("Field4", typeof(string));
                foreach (XElement document in doc.Descendants("billing_document"))
                {
                    dt.Rows.Add(new object[] {
                        (string)document.Element("Field1"),
                        (string)document.Element("Field2"),
                        (string)document.Element("Field3"),
                        (string)document.Element("Field4")
                    });
                }
            }
        }
     
    }
