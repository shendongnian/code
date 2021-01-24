        XElement invoice = xDoc.Root.Element("Invoice");
        List<PMRow> rows = invoice
            .Element("CodingRows")
            .Elements("CodingRow")
            .Select(codingRow => new PMRow
            {
                SupplierCode = invoice.Element("SupplierCode").Value,
                InvoiceNumber = invoice.Element("InvoiceNumber").Value,
                InvoiceDate = DateTime.Parse(invoice.Element("InvoiceDate").Value),
                GrossSum = decimal.Parse(invoice.Element("GrossSum").Value),
                NetSum = decimal.Parse(invoice.Element("NetSum").Value),
                TaxSum = decimal.Parse(invoice.Element("TaxSum").Value),
                CR_GrossSum = decimal.Parse(codingRow.Element("GrossSum").Value),
                AccountNumber = codingRow.Element("AccountCode").Value,
                DimCode1 = codingRow.Element("DimCode1").Value,
            })
            .ToList();
