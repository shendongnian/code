    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<RecordType>().Property(t => t.RecordType).HasMaxLength(1)
                                      .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute(){IsUnique = true}));
    }
