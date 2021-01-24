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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Indice", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Haut", typeof(decimal));
                dt.Columns.Add("Bas", typeof(decimal));
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("X", typeof(decimal));
                dt.Columns.Add("Y", typeof(decimal));
                dt.Columns.Add("Value", typeof(int));
                
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement element in doc.Descendants("Element"))
                {
                    string type = (string)element.Attribute("Type");
                    int indice = (int)element.Attribute("Indice");
                    string name = element.FirstNode.ToString();
                    decimal haut = (decimal)element.Descendants("Haut").FirstOrDefault();
                    decimal bas = (decimal)element.Descendants("Bas").FirstOrDefault();
                    foreach(XElement point in element.Elements("Point"))
                    {
                        string id = (string)point.Attribute("id");
                        decimal x = (decimal)point.Attribute("X");
                        decimal y = (decimal)point.Attribute("Y");
                        int value = (int)point;
                        dt.Rows.Add(new object[] { type, indice, name, haut, bas, id, x, y, value});
                    }
                }
            }
        }
     
    }
