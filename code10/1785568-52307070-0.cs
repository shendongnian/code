    public class User 
    {
      public int UserId {get; set;}
       // .. other User fields.
    
      public virtual Performa Performa {get; set;}
    }
    
    public class Performa
    {
      public int UserId {get; set;}
      // .. other Performa fields.
    
      public virtual User User {get; set;}
    }
    
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
      public UserConfiguration()
      {
        ToTable("Users");
        HasKey(x => x.UserId)
          .Property(x => x.UserId)
          .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
        HasRequired(x => x.Performa)
          .WithRequiredPrincipal(x => x.User);
      }
    }
    
    public class PerformaConfiguration : EntityTypeConfiguration<Performa>
    {
      public PerformaConfiguration()
      {
        ToTable("Performas");
        HasKey(x => x.UserId)
          .Property(x => x.UserId)
          .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      }
    }
