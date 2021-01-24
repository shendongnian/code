    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Invoice>().HasMany(i => i.TransactionLog).WithOne(tl => tl.Invoice).HasForeignKey(tl => tl.DocumentId);
        modelBuilder.Entity<DebitNote>().HasMany(dn => dn.TransactionLog).WithOne(tl => tl.DebitNote).HasForeignKey(tl => tl.DocumentId);
        modelBuilder.Entity<CreditNote>().HasMany(cn => cn.TransactionLog).WithOne(tl => tl.CreditNote).HasForeignKey(tl => tl.DocumentId);
    }
