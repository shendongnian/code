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
                }).FirstOrDefault();
                List<PMRow> rows = tempResults.codingRows.Select(x => new PMRow()
                {
                    SupplierCode = tempResults.supplierCode,
                    InvoiceNumber = tempResults.invoiceNumber,
                    InvoiceDate = tempResults.invoiceDate,
                    GrossSum = tempResults.grossSum,
                    NetSum = tempResults.netSum,
                    TaxSum = tempResults.taxSum,
                    CR_GrossSum = x.crGrossSum,
                    AccountNumber = x.accounNumber,
                    DimCode1 = x.dimCode1
                }).ToList();
                return rows;
             }
