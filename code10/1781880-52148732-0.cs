<!-- language: lang-css -
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
                DataTable dt = new DataTable();
                dt.Columns.Add("Item Name", typeof(string));
                dt.Columns.Add("Item ID", typeof(string));
                dt.Columns.Add("Files Update", typeof(string));
                dt.Columns.Add("File Name", typeof(string));
                dt.Columns.Add("File Update", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement item in doc.Descendants("item"))
                {
                    string name = (string)item.Element("name");
                    string itemID = (string)item.Element("id");
                    foreach (XElement files in item.Elements("files"))
                    {
                        string filesUpdate = (string)files.Element("update");
                        foreach (XElement file in files.Elements("file"))
                        {
                            string filename = (string)file.Element("name");
                            string fileUpdate = (string)file.Element("update");
                            dt.Rows.Add(new object[] { name, itemID, filesUpdate, filename, fileUpdate });
                        }
                    }
                }
            }
        }
    }
