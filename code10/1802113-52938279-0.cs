    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                ParseToPMRows(FILENAME);
            }
            public static List<PMRow> ParseToPMRows(string myFile)
            {
                XDocument xDoc = XDocument.Load(myFile);
                var tempResults = xDoc.Descendants("Invoice").Select(x => new {
                    supplierCode = (string)x.Element("SupplierCode"),
                    invoiceNumber = (string)x.Element("InvoiceNumber"),
                    invoiceDate = (DateTime)x.Element("InvoiceDate"),
                    grossSum = (decimal)x.Element("GrossSum"),
                    netSum = (decimal)x.Element("NetSum"),
                    taxSum = (decimal)x.Element("TaxSum"),
                    codingRows = x.Descendants("CodingRow").Select(y => new {
                        crGrossSum = (decimal)y.Element("GrossSum"),
                        accounNumber = (string)y.Element("AccountCode"),
                        dimCode1 = (string)y.Element("DimCode1")
                    }).ToList()
                }).ToList();
                List<PMRow> rows = tempResults.Select(x => x.codingRows.Select(y => new PMRow()
                {
                    SupplierCode = x.supplierCode,
                    InvoiceNumber = x.invoiceNumber,
                    InvoiceDate = x.invoiceDate,
                    GrossSum = x.grossSum,
                    NetSum = x.netSum,
                    TaxSum = x.taxSum,
                    CR_GrossSum = y.crGrossSum,
                    AccountNumber = y.accounNumber,
                    DimCode1 = y.dimCode1
                })).SelectMany(x => x).ToList();
                return rows;
             }
        }
        public class PMRow
        {
            public string SupplierCode { get; set; }
            public string InvoiceNumber { get; set; }
            public DateTime InvoiceDate { get; set; }
            public decimal GrossSum { get; set; }
            public decimal NetSum { get; set; }
            public decimal TaxSum { get; set; }
            public decimal CR_GrossSum { get; set; }
            public string AccountNumber { get; set; }
            public string DimCode1 { get; set; }
        }
    }
