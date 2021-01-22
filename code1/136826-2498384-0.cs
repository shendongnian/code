    public void InitContext(AppDataContext context)
    {
        DataLoadOptions options = new DataLoadOptions();
        options.LoadWith<Entry>(x => x.Invoice);
        options.LoadWith<Entry>(x => x.Store);
        options.LoadWith<Invoice>(x => x.Period);
        context.DataLoadOptions = options;
    }
    
    public IQueryable<Entry> GetResults(AppDataContext context, int customerId)
    {
        return
        (
            from entry in context.Entries
            join invoice in context.Invoices on entry.EntryInvoiceId equals invoice.InvoiceId
            join period in context.Periods on invoice.InvoicePeriodId equals period.PeriodId
            // LEFT OUTER JOIN, store is not mandatory
            join store in context.Stores on entry.EntryStoreId equals store.StoreId into condStore
            from store in condStore.DefaultIfEmpty()
            where
                (invoice.InvoiceCustomerId == customerId)
            orderby entry.EntryPrice descending
            select entry
        );
    }
