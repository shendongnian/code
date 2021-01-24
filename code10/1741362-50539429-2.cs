    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
       public CommentConfiguration()
       {
          ToTable("Comments");
          HasKey(x => x.CommentID)
             .Property(x => x.CommentD)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
       }
    }
