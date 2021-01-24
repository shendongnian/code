    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<UserJobRecommendations>().HasKey(ujr => new { ujr.UserId, ujr.JobId });
        modelBuilder.Entity<UserJobRecommendations>().HasOne(ujr => ujr.User).WithMany(u=>u.RecommendedJobs).HasForeignKey(ujr => ujr.UserId);
        modelBuilder.Entity<UserJobRecommendations>().HasOne(ujr => ujr.Job).WithMany(j=>j.RecommendedJobs).HasForeignKey(ujr => ujr.JobId);
        modelBuilder.Seed();
        
    }
