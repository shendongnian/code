    public class ParentMap : EntityTypeConfiguration<Parent>
    {
      ToTable("Parents");
      HasKey(x => x.Id)
        .Property(x => x.Id)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
    
    //With Parent ID in Child:
    public class ChildMap : EntityTypeConfiguration<Child>
    {
      ToTable("Children");
      HasKey(x => x.ChildId)
        .Property(x => x.ChildId)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
      HasRequired(x => x.Parent)
        .WithMany()
        .HasForeignKey(x => CustomParentId);
    }
    
    // Without Parent ID in child. (Column in table called "CustomParentId")
    public class ChildMap : EntityTypeConfiguration<Child>
    {
      ToTable("Children");
      HasKey(x => x.ChildId)
        .Property(x => x.ChildId)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
      HasRequired(x => x.Parent)
        .WithMany()
        .Map(x => x.MapKey("CustomParentId"));
    }
