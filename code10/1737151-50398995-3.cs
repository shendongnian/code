    class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
    	public void Configure(EntityTypeBuilder<Like> builder)
    	{
    		builder.HasKey(l => new { l.CommentID, l.UserID });
    	}
    }
