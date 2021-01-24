    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication78
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("fullname", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("registrationType", typeof(string));
                dt.Columns.Add("attending", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement registration in doc.Descendants("Registration"))
                {
                    DataRow newRow = dt.Rows.Add( new object[] {
                        (string)registration.Element("id"),
                        (string)registration.Element("fullName"),
                        (string)registration.Element("emailAddress"),
                        (string)registration.Element("registrationType"),
                        (string)registration.Element("attendingSocialEvent")
                    });
                     
                }
            }
        }
    }
