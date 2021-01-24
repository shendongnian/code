    // Many to many
    modelBuilder.Entity<AnswerTag>().HasOne(m => m.Answer).WithMany(m => m.Tags).HasForeignKey(m => m.AnswerId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<AnswerTag>().HasOne(m => m.Tag).WithMany(m => m.Answers).HasForeignKey(m => m.TagId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<OutcomeTag>().HasOne(m => m.Outcome).WithMany(m => m.Tags).HasForeignKey(m => m.OutcomeId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<OutcomeTag>().HasOne(m => m.Tag).WithMany(m => m.Outcomes).HasForeignKey(m => m.TagId).OnDelete(DeleteBehavior.Restrict);
            
    modelBuilder.Entity<OutcomeGroup>().HasOne(m => m.Outcome).WithMany(m => m.Groups).HasForeignKey(m => m.OutcomeId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<OutcomeGroup>().HasOne(m => m.Group).WithMany(m => m.Outcomes).HasForeignKey(m => m.GroupId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<QuestionGroup>().HasOne(m => m.Question).WithMany(m => m.Groups).HasForeignKey(m => m.QuestionId).OnDelete(DeleteBehavior.Restrict);
    modelBuilder.Entity<QuestionGroup>().HasOne(m => m.Group).WithMany(m => m.Questions).HasForeignKey(m => m.GroupId).OnDelete(DeleteBehavior.Restrict);
