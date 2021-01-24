    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication44
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Author", typeof(string));
                dt.Columns.Add("Contact", typeof(string));
                dt.Columns.Add("Book", typeof(string));
                dt.Columns.Add("Price", typeof(decimal));
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement bookInfo in doc.Descendants("bookinfo"))
                {
                    string author = (string)bookInfo.Descendants("name").FirstOrDefault();
                    string contact = (string)bookInfo.Descendants("contact").FirstOrDefault();
                    foreach (XElement book in bookInfo.Descendants("book"))
                    {
                        string title = (string)book.Element("title");
                        decimal  price = (decimal)book.Element("price");
                        dt.Rows.Add(new object[] { author, contact, title, price });
                    }
                }
            }
        }
    }
