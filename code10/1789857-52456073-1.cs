    public class User
    {
      // User columns...
    
      public virtual ICollection<UserToGroup> UserGroups { get; set; } = new List<UserToGroup>();
    }
    public class UserToGroup
    {
      public int UserId { get; set; }
      public int GroupId { get; set; }
    
      public virtual User User { get; set; }
      public virtual Group Group { get; set; }
    }
    
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
      public UserConfiguration()
      {
        ToTable("user");
        HasKey(x => x.UserId)
          .Property(x => x.UserId)
          .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
       HasMany(x => x.UserGroups)
         .WithRequired(x => x.User); 
    }
    
    public class UserGroupConfiguration : EntityTypeConfiguration<UserGroup>
    {
      public UserGroupConfiguration()
      {
        ToTable("usertogroup");
        HasKey(x => new { x.UserId, x.GroupId });
      }
    }
