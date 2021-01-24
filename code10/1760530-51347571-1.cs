    public void Update(Invoice record)
    {
        var missingRows = dB.InvoiceRows.Where(i => i.InvoiceId == record.Id)
                            .Except(record.Rows);
        dB.InvoiceRows.RemoveRange(missingRows);
        dB.Invoices.Update(record);
        dB.SaveChanges();
    }
