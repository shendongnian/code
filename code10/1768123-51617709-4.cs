    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
          public UserConfiguration()
          {
                HasKey(e => e.Id);
    
                Property(e => e.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
                Property(e => e.CreatedBy)
                    .IsUnicode(false)
                    .HasMaxLength(255);
    
                Property(e => e.UpdateBy)
                    .IsUnicode(false)
                    .HasMaxLength(255);
          }
     }
