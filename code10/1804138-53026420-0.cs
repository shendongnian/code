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
                dt.Columns.Add("SalesTaxAmount", typeof(decimal));
                dt.Columns.Add("PaymentAmount", typeof(decimal)); 
                dt.Columns.Add("RecurringProfileID", typeof(string)); 
                dt.Columns.Add("TransactedDateTimeUTC", typeof(DateTime)); 
                dt.Columns.Add("TransactedDateTime", typeof(DateTime)); 
                dt.Columns.Add("NumberOfDays", typeof(int)); 
                dt.Columns.Add("LicenseSize", typeof(int));
                dt.Columns.Add("LicenseSizeDescription=", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement transaction in doc.Descendants("Transaction"))
                {
                    dt.Rows.Add(new object[] {
                        (decimal?)transaction.Attribute("SalesTaxAmount"),
                        (decimal?)transaction.Attribute("PaymentAmount"),
                        (string)transaction.Attribute("RecurringProfileID"),
                        (DateTime)transaction.Attribute("TransactedDateTimeUTC"),
                        (DateTime)transaction.Attribute("TransactedDateTime"),
                        (int?)transaction.Attribute("NumberOfDays"),
                        (int)transaction.Attribute("LicenseSize"),
                        (string)transaction.Attribute("LicenseSizeDescription")
                    });
                }
     
            }
        }
    }
