    var likeEntity = modelBuilder.Entity<Like>();
    likeEntity.HasRequired(like => like.User)
        .WithMany(user => user.Likes)
        .HasForeignKey(like => like.LikedByUserId);
    likeEntity.HasRequired(like  => like.Comment)
        .WithMany(comment => comment.Likes)
        .HasForeignKey(like => like.CommentId);
