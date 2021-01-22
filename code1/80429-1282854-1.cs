    var Invoices = new[] {
        new { InvoiceID = 1, CustomerID = 2, Amount = 2.5m, Date = DateTime.Today },
        new { InvoiceID = 2, CustomerID = 3, Amount = 5.5m, Date = DateTime.Today }
    }.AsQueryable();
    var Payments = new[] {
        new { InvoiceID = 1, Amount = 1m }
    }.AsQueryable();
