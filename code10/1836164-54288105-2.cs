    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<MemberReview>()
            .HasKey(e => new { e.RevieweeId, e.ReviewerId });
        builder.Entity<ProductReview>()
            .HasKey(e => new { e.ReviewerId, e.ReviewedProductId });
        builder.Entity<MemberReview>()
            .HasOne<User>(e => e.Reviewer)
            .WithMany(e => e.MemberReviews)
            .HasForeignKey(e => e.ReviewerId)
            .OnDelete(DeleteBehavior.Restrict); ////////
                                                      //
        builder.Entity<MemberReview>()                //
            .HasOne<User>(e => e.Reviewee)            /// => only one of these two can be cascade
            .WithMany(e => e.ReviewedMembers)         //
            .HasForeignKey(e => e.RevieweeId)         //
            .OnDelete(DeleteBehavior.Restrict); ////////
        builder.Entity<ProductReview>()
            .HasOne<User>(e => e.Reviewer)
            .WithMany(e => e.ReviewedProducts)
            .HasForeignKey(e => e.ReviewerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
