    public partial class TransactionLog
    {
        public int TransactionLogId { get; set; }
        public Nullable<int> DocumentTypeId { get; set; }
        public Nullable<decimal> Amount { get; set; }
    
        public virtual CreditNote CreditNote { get; set; }
        public virtual DebitNote DebitNote { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
    
        public virtual TransactionLog TransactionLog { get; set; }
    }
    public partial class CreditNote
    {
        public int CreditNoteId { get; set; }
        public string CreditNoteNumber { get; set; }
        public decimal Amount { get; set; }
    
        public virtual TransactionLog TransactionLog { get; set; }
    }
    public partial class DebitNote
    {
        public int DebitNoteId { get; set; }
        public string DebitNoteNumber { get; set; }
        public decimal Amount { get; set; }
    
        public virtual TransactionLog TransactionLog { get; set; }
    }
