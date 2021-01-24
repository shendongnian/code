    public class SampleContext : DbContext
    {
        public SampleContext()
            : base("name=YourConnection")
        {
        }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<CreditOrder> CreditOrders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesOrder>()
                .HasKey(so => so.Id);
            modelBuilder.Entity<CreditOrder>()
                .HasKey(co => co.Id);
            modelBuilder.Entity<Invoice>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<UploadedFile>()
                .HasKey(uf => uf.Id);
            modelBuilder.Entity<UploadedFile>()
                .HasRequired(u => u.SalesOrder)
                .WithMany(s => s.UploadedFiles)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UploadedFile>()
                .HasRequired(u => u.CreditOrder)
                .WithMany(c => c.UploadedFiles)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UploadedFile>()
                .HasRequired(u => u.Invoice)
                .WithMany(c => c.UploadedFiles)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UploadedFile>()
                .Property(uf => uf.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SalesOrder>()
                .Property(so => so.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CreditOrder>()
                .Property(co => co.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Invoice>()
                .Property(i => i.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
    }
    
    // Collections of navigation properties should be included in classes for a one-to-many relationship
    public class SalesOrder
    {
        public int Id { get; set; }
        public string MyColumn { get; set; }
        public IList<UploadedFile> UploadedFiles { get; set; }
    }
    public class CreditOrder
    {
        public int Id { get; set; }
        public string MyColumn { get; set; }
        public IList<UploadedFile> UploadedFiles { get; set; }
    }
    public class Invoice
    {
        public int Id { get; set; }
        public string MyColumn { get; set; }
        public IList<UploadedFile> UploadedFiles { get; set; }
    }
    public class UploadedFile
    {
        public int Id { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public CreditOrder CreditOrder { get; set; }
        public Invoice Invoice { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
    public class SalesOrder
    {
        public int Id { get; set; }
        public string MyColumn { get; set; }
        public IList<UploadedFile> UploadedFiles { get; set; }
    }
    public class CreditOrder
    {
        public int Id { get; set; }
        public string MyColumn { get; set; }
        public IList<UploadedFile> UploadedFiles { get; set; }
    }
    public class Invoice
    {
        public int Id { get; set; }
        public string MyColumn { get; set; }
        public IList<UploadedFile> UploadedFiles { get; set; }
    }
    public class UploadedFile
    {
        public int Id { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public CreditOrder CreditOrder { get; set; }
        public Invoice Invoice { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
