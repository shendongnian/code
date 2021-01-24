    var notCorrected = 
        _context.Table1
                .SelectMany(table => table.Invoices.Where(i => period.Contains(i.InvoiceId))
                .GroupBy(invoice => invoice.Id)
                .Where(group => group.Any(invoice => invoice.Corrected) == false)
                .SelectMany(group => group)
                .ToList();
