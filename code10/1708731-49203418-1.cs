    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> originalInvoices = doc.Descendants("Invoice").ToList();
                var groups = originalInvoices.GroupBy(x => (string)x.Element("Hash")).ToList();
                var finalInvoices = groups.Select(x => new {
                    unit = x.Descendants("Unit").Sum(z => (int)z),
                    credit = x.Descendants("Credit").Sum(z => (int)z),
                    tax = x.Descendants("Tax").Sum(z => (int)z),
                    net = x.Descendants("Net").Sum(z => (int)z),
                    gross = x.Descendants("Gross").Sum(z => (int)z),
                    first = x.First()
                }).ToList();
                foreach (var finalInvoice in finalInvoices)
                {
                    finalInvoice.first.Element("Line").SetElementValue("Unit", finalInvoice.unit);
                    finalInvoice.first.Element("Line").SetElementValue("Credit", finalInvoice.credit);
                    finalInvoice.first.Element("Document").SetElementValue("Tax", finalInvoice.tax);
                    finalInvoice.first.Element("Document").SetElementValue("Net", finalInvoice.net);
                    finalInvoice.first.Element("Document").SetElementValue("Gross", finalInvoice.gross);
                }
               
                doc.Element("Sales").ReplaceWith(new XElement("Sales", finalInvoices.Select(x => x.first)));
            }
        }
    }
