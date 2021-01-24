    public InvoiceLine GetLastInvoiceLineByInvoices(List<Invoice> invoices, List<InvoiceLine> invoiceLine)
    {
        if (invoices != null)
        {
           return invoiceLine.Where(s => s.WorkmanshipId != null && invoices.Select(p=> p.Id).Contains(s.InvoiceId) ).OrderByDescending(s=> s.InvoiceDate).FirstOrDefault();
        }
        return null;
    }
