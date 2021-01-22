       public Invoices: List<Invoice>
       {
            public Invoices OverDueInvoices 
            { get {return this.Where( i => i.IsOverdue()); } }
            public Invoices InvoicesByState(string stateAbbrev)
            { return this.Where( i => i.State == stateAbbrev);  }
            public Invoice this[int invoiceId]
            { get { return this.Find( i => i.InvoiceId == invoiceId); } }
            // extra functionality as required 
       }
  
