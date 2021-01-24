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
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                int maxString = doc.Descendants(ns + "Resultstring").Select(x => x.Descendants("string").Count()).Max();
                
                DataTable dt = new DataTable();
                dt.Columns.Add("KEY", typeof(string));
                dt.Columns.Add("TYPE", typeof(string));
                for (int i = 0; i < maxString; i++)
                {
                    dt.Columns.Add("RESULTING_ID_" + (i + 1).ToString(), typeof(string));
                }
                
                foreach (XElement resultingString in doc.Descendants(ns + "Resultstring"))
                {
                    string key = (string)resultingString.Element("Key");
                    string type = (string)resultingString.Element("Type");
                    List<string> row =  resultingString.Descendants("string").Select(x => (string)x).ToList();
                    row.Insert(0, key);
                    row.Insert(1, type);
                    dt.Rows.Add(row.ToArray());
                }
     
            }
        }
     
    }
