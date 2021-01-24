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
                dt.Columns.Add("ClientLoanNumber", typeof(string));
                dt.Columns.Add("UploadedDt", typeof(DateTime));
                dt.Columns.Add("Error", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> failed = doc.Descendants("CDR_STATUS").Where(x => (string)x.Attribute("UploadStatus") == "Failed").ToList();
                foreach (var fail in failed)
                {
                    DataRow newRow = dt.Rows.Add();
                    newRow["ClientLoanNumber"] = (string)fail.Attribute("CWLLoanNumber");
                    newRow["UploadedDt"] = DateTime.ParseExact((string)fail.Attribute("UploadedDt"), "M/dd/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                    newRow["Error"] = string.Join("\n", fail.Elements("CDR_ERROR").Select(x => (string)x.Attribute("Message")));
                }
               
            }
        }
    }
