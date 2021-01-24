    PaymentApproval pa;
    /* populate regular fields in pa */
    
    List<PaymentProposalDetail> details = new List<PaymentProposalDetail>();
    
    foreach (data UIdata in UIdataStruct)
    {
        PaymentProposalDetail pd = new PaymentProposalDetail();
        pd.InvoiceNumber = UIdata.invoiceNumber;
        pd.PayAmount = UIdata.payAmount;
        pd.InvoiceCurrenct = UIdata.invoiceCurrency;
        
        details.Add(pd);
    }
    
    pa.Details = details.ToArray(); 
