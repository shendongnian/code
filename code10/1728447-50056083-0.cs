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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new XML_DataSet(FILENAME);
            }
        }
        public class XML_DataSet
        {
            static DataSet ds = new DataSet();
            public XML_DataSet(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                foreach(XElement table in doc.Descendants("table"))
                {
                    ds.Tables.Add(ReadTable(table));
                }
            }
            private DataTable ReadTable(XElement table)
            {
                DataTable dt = new DataTable();
                Boolean first = true;
                foreach (XElement xRow in table.Elements("row"))
                {
                    if (first)
                    {
                        foreach (XElement field in xRow.Elements("field"))
                        {
                            dt.Columns.Add((string)field.Attribute("name"), typeof(string));
                        }
                        first = false;
                    }
                    DataRow newRow = dt.Rows.Add();
                    foreach (XElement field in xRow.Elements("field"))
                    {
                        newRow[(string)field.Attribute("name")] = (string)field;
                    }
                }
                return dt;
            }
        }
    }
