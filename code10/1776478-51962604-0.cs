    IQueryable<DocumentLine> customerDocumentLines = dbContext.Customers
        .Select(customer => new DocumentLine()
        {
             FirstName = customer.FirstName,
             LastName = customer.LastName,
             ...
             // etc, fill all DocumentLine properties
        });
