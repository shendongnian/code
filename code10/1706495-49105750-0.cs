    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string URL = @"https://www.w3schools.com/xml/cd_catalog.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TITLE", typeof(string));
                dt.Columns.Add("ARTIST", typeof(string));
                dt.Columns.Add("COUNTRY", typeof(string));
                dt.Columns.Add("COMPANY", typeof(string));
                dt.Columns.Add("PRICE", typeof(decimal));
                dt.Columns.Add("YEAR", typeof(int));
                XDocument doc = XDocument.Load(URL);
                foreach (XElement cd in doc.Descendants("CD"))
                {
                    dt.Rows.Add(new object[] {
                        (string)cd.Element("TITLE"),
                        (string)cd.Element("ARTIST"),
                        (string)cd.Element("COUNTRY"),
                        (string)cd.Element("COMPANY"),
                        (decimal)cd.Element("PRICE"),
                        (int)cd.Element("YEAR")
                    });
                }
                string[] titles = dt.AsEnumerable().Select(x => x.Field<string>("TITLE")).ToArray();
            }
        }
    }
