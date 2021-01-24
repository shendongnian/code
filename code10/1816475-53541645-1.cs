    class CurrentContext : DbContext
    {
        public DbSet<SystemArea> SystemAreas {get; set;}
        public DbSet<SystemAreaFunctionality> SystemAreaFunctionalities {get; set;}
    }
