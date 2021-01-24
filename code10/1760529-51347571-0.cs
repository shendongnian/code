    public void Update(Invoice record)
    {
        // Find invoice in db
        var invoice = dB.Invoices.First(i => i.Id == record.Id);
        var missingRows = invoice.Rows.Except(record.Rows);
        dB.InvoiceRow.RemoveRange(missingRows);
        dB.Invoices.Update(record);
        dB.SaveChanges();
    }
