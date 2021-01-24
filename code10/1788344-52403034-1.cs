    var invoice = new Invoice()
        {
            InvoiceNumber = "Inv099",
            Amount = 66m,
            InvoiceLog = new Collection<TransactionLog>()
            {
                new TransactionLog(){DocumentTypeId = 1, Amount = 66m}
            }
        };
        var creditNote = new CreditNote()
        {
            CreditNoteNumber = "DN002",
            Amount = 99.99m,
            CreditLog = new Collection<TransactionLog>()
            {
                new TransactionLog(){DocumentTypeId = 3, Amount = 99.99m}
            }
        };
        var debitNote = new DebitNote()
        {
            DebitNoteNumber = "CN008",
            Amount = 77.77m,
            DebitLog = new Collection<TransactionLog>()
            {
                new TransactionLog(){DocumentTypeId = 2, Amount = 77.77m}
            }
        };
        using (var context = new TestMVCEntities())
        {
            context.Invoices.Add(invoice);
            context.CreditNotes.Add(creditNote);
            context.DebitNotes.Add(debitNote);
            context.SaveChanges();
        }  
  
