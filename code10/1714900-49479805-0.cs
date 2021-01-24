    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            //File
            const string FILE = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILE);
                XElement AuditFile = doc.Root;
                XNamespace ns = AuditFile.GetDefaultNamespace();
                List<XElement> originalInvoices = doc.Descendants(ns + "Invoice").ToList();
                var groups = originalInvoices.GroupBy(x => (string)x.Element(ns + "Hash")).ToList();
                var finalInvoices = groups.Select(x => new
                {
                    unit = x.Descendants(ns + "UnitPrice").Sum(z => (decimal)z),
                    credit = x.Descendants(ns + "CreditAmount").Sum(z => (decimal)z),
                    tax = x.Descendants(ns + "TaxPayable").Sum(z => (decimal)z),
                    net = x.Descendants(ns + "NetTotal").Sum(z => (decimal)z),
                    gross = x.Descendants(ns + "GrossTotal").Sum(z => (decimal)z),
                    first = x.First()
                }).ToList();
                foreach (var finalInvoice in finalInvoices)
                {
                    finalInvoice.first.Element(ns + "Line").SetElementValue(ns + "UnitPrice", finalInvoice.unit);
                    finalInvoice.first.Element(ns + "Line").SetElementValue(ns + "CreditAmount", finalInvoice.credit);
                    finalInvoice.first.Element(ns + "DocumentTotals").SetElementValue(ns + "TaxPayable", finalInvoice.tax);
                    finalInvoice.first.Element(ns + "DocumentTotals").SetElementValue(ns +"NetTotal", finalInvoice.net);
                    finalInvoice.first.Element(ns + "DocumentTotals").SetElementValue(ns + "GrossTotal", finalInvoice.gross);
                }
                doc.Descendants(ns + "SalesInvoices").FirstOrDefault().ReplaceWith(new XElement("SalesInvoices", finalInvoices.Select(x => x.first)));
                Console.WriteLine(doc);
                Console.ReadKey();
            }
        }
    }
