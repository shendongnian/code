    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication51
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
     
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("KEY", typeof(string));
                dt.Columns.Add("RESULTING_ID", typeof(string));
                dt.Columns.Add("TYPE", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                foreach (XElement resultingString in doc.Descendants(ns + "Resultstring"))
                {
                   string key = (string)resultingString.Element("Key");
                   string type = (string)resultingString.Element("Type");
                   string ids = string.Join(";", resultingString.Descendants("string").Select(x => (string)x));
                   dt.Rows.Add(new object[] { key, ids, type });
                }
     
            }
        }
     
    }
