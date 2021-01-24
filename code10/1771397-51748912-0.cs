    class BaseDbContext : DbContext
    {
         public DbSet<Client> Clients {get; set;}   // both Pms and Grms have Clients
         ...
    }
    class PmsEntities : BaseDbContext 
    {
         public DbSet<OnlyPmsType> OnlyPmsTypes {get; set;}    // only in Pms
         ...
    }
    class PmsEntities : BaseDbContext  
    {
         public DbSet<OnlyGrmsType> OnlyGrmsTypes {get; set;}    // only in Grms
         ...
    }
