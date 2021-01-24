    public class User
    {
      // User columns...
    
      public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
    
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
      public UserConfiguration()
      {
        ToTable("user");
        HasKey(x => x.UserId)
          .Property(x => x.UserId)
          .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
       HasMany(x => x/Groups)
         .WithMany() // if Group has no Users collection, otherwise .WithMany(x => x.Users)
         .Map(x => 
         {
           x.ToTable("usertogroup");
           x.MapLeftKey("userId");
           x.MapRightKey("groupId");
         });
     }
    }
