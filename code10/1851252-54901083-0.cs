    public class YourDBContext: DbContext 
    {
        public YourDBContext(): base() 
        {
        }
       
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyTransactions>()
                .HasRequired(c => c.Contracts)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
