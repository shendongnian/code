    class MyDbContext : DbContext
    {
        public DbSet<Enquiry> Enquiries {get; set;}
        public DbSet<FollowUp> FollowUps {get; set;}
    }
