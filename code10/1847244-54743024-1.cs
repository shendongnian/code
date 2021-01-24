    protected override void OnModelCreating (System.Data.Entity.DbModelBuilder modelBuilder)
    {
         var myClassEntity = modelBuilder.Entity<MyClass>();
         // MyClass has a property MyText with a maximum length of 10
         myClassEntity.Property(entity => entity.MyText
                      .HasMaxLength(10);
         ... configure other MyClass properties.
    }
