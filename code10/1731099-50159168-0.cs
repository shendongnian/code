    modelBuilder.Entity<Table1>().HasKey(t => t.ID);
    modelBuilder.Entity<Table1>().Property(t =>t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
    modelBuilder.Entity<Table1>()
                .HasOptional(t1 => t1.Table2)
                .WithRequired(t2 => t2.Table1).Map(m => m.MapKey("ID"));
    
