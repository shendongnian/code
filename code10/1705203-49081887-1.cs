    modelBuilder.Entity<MessageRecipients>()
    	.HasKey(bc => new { bc.UserId, bc.MessageId });
    
    modelBuilder.Entity<MessageRecipients>()
    	.HasOne(bc => bc.User)
    	.WithMany(b => b.Messages)
    	.HasForeignKey(bc => bc.UserId)
    	.OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<MessageRecipients>()
    	.HasOne(bc => bc.Message)
    	.WithMany(c => c.Recipients)
    	.HasForeignKey(bc => bc.MessageId)
    	.OnDelete(DeleteBehavior.Restrict);
