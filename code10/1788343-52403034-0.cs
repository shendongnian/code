    public class TestMVCEntities : DbContext
    {
        public TestMVCEntities()
            : base("name=TestMVCEntities")
        {
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<DebitNote> DebitNotes { get; set; }
        public DbSet<CreditNote> CreditNotes { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionLog>()
                .HasRequired(p => p.Invoice)
                .WithMany(p => p.InvoiceLog)
                .HasForeignKey(p => p.DocumentId);
            modelBuilder.Entity<TransactionLog>()
                .HasRequired(p => p.DebitNote)
                .WithMany(p => p.DebitLog)
                .HasForeignKey(p => p.DocumentId);
            modelBuilder.Entity<TransactionLog>()
                .HasRequired(p => p.CreditNote)
                .WithMany(p => p.CreditLog)
                .HasForeignKey(p => p.DocumentId);
        }
    }
    public partial class TransactionLog
    {
        public int TransactionLogId { get; set; }
        public int? DocumentId { get; set; }
        public int? DocumentTypeId { get; set; }
        public decimal? Amount { get; set; }
        public CreditNote CreditNote { get; set; }
        public Invoice Invoice { get; set; }
        public DebitNote DebitNote { get; set; }
    }
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public ICollection<TransactionLog> InvoiceLog { get; set; }
    }
    public partial class DebitNote
    {
        public int DebitNoteId { get; set; }
        public string DebitNoteNumber { get; set; }
        public decimal Amount { get; set; }
        public ICollection<TransactionLog> DebitLog { get; set; }
    }
    public partial class CreditNote
    {
        public int CreditNoteId { get; set; }
        public string CreditNoteNumber { get; set; }
        public decimal Amount { get; set; }
        public ICollection<TransactionLog> CreditLog { get; set; }
    }  
  
