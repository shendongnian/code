    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication83
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement sls = doc.Descendants("sls").FirstOrDefault();
                DataTable dt = new DataTable();
                string[] columns = sls.Elements().Select(x => x.Name.LocalName).Distinct().ToArray();
                foreach (string column in columns)
                {
                    dt.Columns.Add(column, typeof(string));
                }
                DataRow newRow = null;
                foreach (XElement element in sls.Elements())
                {
                    string columnName = element.Name.LocalName;
                    if (columnName == "ppsitecode") newRow = dt.Rows.Add();
                    newRow[columnName] = (string)element;
                }
            }
        
        }
    }
