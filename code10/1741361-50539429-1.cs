    public class PhotoConfiguration : EntityTypeConfiguration<Photo>
    {
       public PhotoConfiguration()
       {
          ToTable("Photos");
          HasKey(x => x.PhotoID)
             .Property(x => x.PhotoID)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // This informs EF that the database will be assigning the PK.
    
          HasMany(x => x.Comments)
             .WithRequired()
             .Map(x => x.MapKey("PhotoID")); // This tells EF to join comments to a Photo /w the PhotoID on the Comment table. HasMany says a Photo has many comments, and WithRequired() points to a non-nullable FK on Comment, but no navigation property coming back to Photo.
       }
    }
