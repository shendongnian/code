    List<Payment> paymentDetails = xml.Descendants("payment")
            .Select(x => new Payment()
            {
                PaymentId = x.Element("paymentId").Value,
                PaymentAmount = (decimal)x.Element("paymentAmount"),
                InvoiceCollection = x.Elements("invoice")
                    .Where(i => i.Element("invoiceId").Value.Contains("K"))
                    .Select(i => new Invoice()
                    {
                        InvoiceId = i.Element("invoiceId").Value.ToString(),
                        InvoiceAmount = (decimal)i.Element("invoiceAmount"),
                        InvoiceDate = (DateTime)i.Element("invoiceDate")
                    }).ToList()
            }).ToList();
