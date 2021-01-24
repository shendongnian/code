    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure table1 & table2 entity
        modelBuilder.Entity<Table2>()
                    .HasOptional(s => s.Table1) // Mark Table1 property optional in Table2 entity
                    .WithRequired(ad => ad.Table2); // mark Table1 property as required in Table2 entity. Cannot save Table1 without Table
    }
