                foreach (var finalInvoice in finalInvoices)
                {
                    finalInvoice.first.Element(ns + "Line").SetElementValue(ns + "UnitPrice", finalInvoice.unit);
                    finalInvoice.first.Element(ns + "Line").SetElementValue(ns + "CreditAmount", finalInvoice.credit);
                    finalInvoice.first.Element(ns + "DocumentTotals").SetElementValue(ns + "TaxPayable", finalInvoice.tax);
                    finalInvoice.first.Element(ns + "DocumentTotals").SetElementValue(ns + "NetTotal", finalInvoice.net);
                    finalInvoice.first.Element(ns + "DocumentTotals").SetElementValue(ns + "GrossTotal", finalInvoice.gross);
                }
                XElement salesInvoices = doc.Descendants(ns + "SalesInvoices").FirstOrDefault();
                XElement numberOfEntries = salesInvoices.Element(ns + "NumberOfEntries");
                XElement totalDebit = salesInvoices.Element(ns + "TotalDebit");
                XElement totalCredit = salesInvoices.Element(ns + "TotalCredit");
                salesInvoices.ReplaceWith(new XElement(ns + "SalesInvoices", new object[] {
                    numberOfEntries,
                    totalDebit,
                    totalCredit,
                    finalInvoices.Select(x => x.first)
                }));
