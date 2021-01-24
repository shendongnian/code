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
                dt.Columns.Add("Age", typeof(int));
                dt.Columns.Add("Birth", typeof(DateTime));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Mobile Code", typeof(int));
                dt.Columns.Add("Mobile Phone", typeof(string));
                dt.Columns.Add("Work Code", typeof(int));
                dt.Columns.Add("Work Phone", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement row in doc.Descendants("MemberSummary"))
                {
                    DataRow newRow = dt.Rows.Add();
                    newRow["Age"] = (int)row.Element("Age");
                    newRow["Birth"] = DateTime.ParseExact((string)row.Element("DateOfBirth"), "MM:dd:yyyy:HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    newRow["Email"] = (string)row.Element("EmailAddress");
                    newRow["Mobile Code"] = (int)row.Element("MobilePhone").Element("CountryCode");
                    newRow["Mobile Phone"] = (string)row.Element("MobilePhone").Element("Number");
                    newRow["Work Code"] = (int)row.Element("WorkPhone").Element("CountryCode");
                    newRow["Work Phone"] = (string)row.Element("WorkPhone").Element("Number");
                }
            }
        }
    }
