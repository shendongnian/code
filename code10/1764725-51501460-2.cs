    //don't need a compound key for answers... 
    //easier to just let each answer be entirely unique.            
    modelBuilder.Entity<Answer>().HasKey(m => m.Id );
    modelBuilder.Entity<Answer>().HasRequired(m => m.Question)
        .WithMany(q => q.Answers).HasForeignKey(m => m.QuestionId);
            
    modelBuilder.Entity<Question>()
        .HasOptional(m => m.DefaultAnswer)
        .WithOptionalDependent(m => m.Question);
    //default answer is basically a mapping table between questions and answers.
    //so it has a compound key.  In fact the table should consist of ONLY these two key
    //fields...
    modelBuilder.Entity<DefaultAnswer>()
        .HasKey(m => new { m.AnswerId, m.QuestionId });              
