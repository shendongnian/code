    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MotherTable>().ToTable("MotherTable").HasKey<int>(c => c.MotherId);
        modelBuilder.Entity<ChildTable1>().ToTable("ChildTable1");
        modelBuilder.Entity<ChildTable2>().ToTable("ChildTable2");
        modelBuilder.Entity<GrandChild1>().ToTable("GrandChild1");
        modelBuilder.Entity<GrandChild2>().ToTable("GrandChild2");
    }
