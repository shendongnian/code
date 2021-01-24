    dbConnection.Execute<Invoice, LineItem, Invoice>("query", (invoice, lineItem) =>
    {
         invoice.LineItem = lineItem;
         return invoice;
    }, new { Id = "Parameters here" });
