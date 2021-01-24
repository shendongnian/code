    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        base.OnModelCreating(modelBuilder);
        
        // Many-to-Many configuration between User and Job 
        modelBuilder.Entity<UserJobRecommendations>().HasKey(ujr => new { ujr.UserId, ujr.JobId });
        modelBuilder.Entity<UserJobRecommendations>().HasOne(ujr => ujr.User).WithMany(u=>u.RecommendedJobs)
                                                     .HasForeignKey(ujr => ujr.UserId).OnDelete(DeleteBehavior.Restrict);;
        modelBuilder.Entity<UserJobRecommendations>().HasOne(ujr => ujr.Job).WithMany(j=>j.RecommendedJobs)
                                                     .HasForeignKey(ujr => ujr.JobId).OnDelete(DeleteBehavior.Restrict);;
        // RecommendedBy ForeignKey Configuraiton
        modelBuilder.Entity<UserJobRecommendations>().HasOne(ujr => ujr.RecommendedBy).WithMany().HasForeignKey(ujr => ujr.RecommendedById);
        modelBuilder.Seed();
        
    }
