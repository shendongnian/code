    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassA>().Property<int>("ClassAId");
        modelBuilder.Entity<ClassA>().HasKey("ClassAId"); // <=== This is a SOLUTION
        modelBuilder.Entity<ClassB>().Property<int>("ClassBId");
        modelBuilder.Entity<ClassB>().Property<int>("AnotherClassId");
        modelBuilder.Entity<ClassB>().HasOne(p => p.AnotherClass).WithMany().HasForeignKey("AnotherClassId");
    }
